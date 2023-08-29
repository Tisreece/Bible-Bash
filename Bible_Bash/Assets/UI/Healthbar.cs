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

    //Handles the Coroutine
    private float HPLossDuration = 0.5f;
    private float HPLossElapsedTime = 0.0f;

    //Handles Health Values
    private float DisplayedHealth;
    private float CurrentHealth; //I don't think this is a redundancy. This is the value the Healthbar thinks it should be before lerping has been done.

    // Start is called before the first frame update
    void Start()
    {
        SetInitialHealth();
    }

    public void UpdateHealth(float NewHealth, float MaxHealth)
    {
        // TODO This will be the place where we will handle both increases and decreases in health. Currently this only handles decreases in health
        if (NewHealth < CurrentHealth)
        {
            LightHPFill = NewHealth / HealthManager.MaxHealth;
            LightHP.fillAmount = LightHPFill;
            StartCoroutine(HPLoss(DarkHPFill, NewHealth));
        }
    }

    private IEnumerator HPLoss(float InitialFill, float TargetHealth)
    {
        while (HPLossElapsedTime < HPLossDuration)
        {
            HPLossElapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(HPLossElapsedTime / HPLossDuration);
            float TargetFill = TargetHealth / HealthManager.MaxHealth;
            DarkHP.fillAmount = Mathf.Lerp(InitialFill, TargetFill, t); //It will be best to lerp the health then update the UI. This way we can set the currently displayed health for future HP changes
            yield return null;
        }

        CurrentHealth = TargetHealth;
    }

    private void SetInitialHealth()
    {
        LightHPFill = HealthManager.CurrentHealth / HealthManager.MaxHealth;
        DarkHPFill = HealthManager.CurrentHealth / HealthManager.MaxHealth;
        LightHP.fillAmount = LightHPFill;
        DarkHP.fillAmount = DarkHPFill;
        CurrentHealth = HealthManager.CurrentHealth;
        DisplayedHealth = HealthManager.CurrentHealth;
    }
}
