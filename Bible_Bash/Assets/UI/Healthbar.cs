using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Canvas Canvas;
    public Image LightHP;
    public Image DarkHP;
    public HealthManager HealthManager;

    private float DarkHPFill;
    private float LightHPFill;

    //Handles the HP Loss Coroutine
    private float HPLossDuration = 0.5f;
    private float HPLossElapsedTime = 0.0f;
    //private bool HPLossRunning = false; //We may need this in the future

    //Damage Taken Coroutine
    private bool DamageTakenRunning = false;
    private float DamageTakenDuration = 1.0f;

    //Handles Health Values
    //private float DisplayedHealth; //Set at the end of each frame of the coroutine. // This is currently not being used
    //private float PreviousHealth; //Set at the beginning of coroutines //This is currently not being used
    private float CurrentHealth; //Set when new HP is announced

    // Start is called before the first frame update
    void Start()
    {
        SetInitialHealth();
    }

    public void UpdateHealth(float NewHealth, float MaxHealth)
    {
        // TODO This will be the place where we will handle both increases and decreases in health. Currently this only handles decreases in health
        if (NewHealth < CurrentHealth) //We have taken damage
        {
            CurrentHealth = NewHealth;
            LightHPFill = CurrentHealth / HealthManager.MaxHealth;
            LightHP.fillAmount = LightHPFill;
            if (DamageTakenRunning == true)
            {
                StopCoroutine(DamageTakenTimer());
            }
            StartCoroutine(DamageTakenTimer());
        }
    }

    private IEnumerator DamageTakenTimer()
    {
        DamageTakenRunning = true;
        yield return new WaitForSeconds(DamageTakenDuration);
        DamageTakenRunning = false;
        StartCoroutine(HPLoss(DarkHPFill, CurrentHealth));
    }

    private IEnumerator HPLoss(float InitialFill, float TargetHealth)
    {
        HPLossElapsedTime = 0.0f;
        //HPLossRunning = true; //Keep pls

        while (HPLossElapsedTime < HPLossDuration)
        {
            HPLossElapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(HPLossElapsedTime / HPLossDuration);
            float TargetFill = TargetHealth / HealthManager.MaxHealth;
            DarkHP.fillAmount = Mathf.Lerp(InitialFill, TargetFill, t); //It may be best to lerp the health then update the UI. This way we can set the currently displayed health for future HP changes
            DarkHPFill = DarkHP.fillAmount;
            yield return null;
        }

        if (DamageTakenRunning == false) //We don't want to set the fill amount to current health if there is already a health update pending
        {
            DarkHPFill = ResetFill();
        }
        //HPLossRunning = false; //Keep pls
    }

    private void SetInitialHealth()
    {
        CurrentHealth = HealthManager.CurrentHealth;
        //PreviousHealth = HealthManager.CurrentHealth; //We may need this in the future
        //DisplayedHealth = HealthManager.CurrentHealth; //We may need this in the future
        LightHPFill = ResetFill();
        DarkHPFill = ResetFill();
        LightHP.fillAmount = LightHPFill;
        DarkHP.fillAmount = DarkHPFill;
    }

    private float ResetFill()
    {
        return CurrentHealth / HealthManager.MaxHealth;
    }
}
