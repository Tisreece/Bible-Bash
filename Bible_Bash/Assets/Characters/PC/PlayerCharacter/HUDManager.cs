using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    //All things related to the Ability Bar
    public Canvas AbilityBarToDraw;
    public AbilityManager AbilityManager;
    [HideInInspector] public Canvas AbilityBarCanvas;
    private AbilityBar AbilityBarScript;

    //Handles the AbilityBar Cooldown Coroutines
    private Coroutine CD1Coroutine;
    private float CD1ElapsedTime;
    private Coroutine CD2Coroutine;
    private float CD2ElapsedTime;
    private Coroutine CD3Coroutine;
    private float CD3ElapsedTime;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Relates to the Ability Bar

    //Any time an ability may need to change its icon they call this
    public void UpdateAbilityIcon(AbilityMaster Ability)
    {
        int AbilitySlot = Ability.AbilitySlotIndex;
        bool CanActivate = Ability.CheckCanActivate();

        if (AbilitySlot == 1)
        {
            SetOverlayVisibility(AbilityBarScript.Ability1Overlay, !CanActivate);
            if (Ability.UsesCooldown == true && Ability.OnCooldown == true)
            {
                CD1Coroutine = StartCoroutine(CooldownFill(AbilityBarScript.Ability3Overlay, Ability.Stat.Cooldown, AbilitySlot));
            }
        }

        if (AbilitySlot == 2)
        {
            SetOverlayVisibility(AbilityBarScript.Ability2Overlay, !CanActivate);
            if (Ability.UsesCooldown == true && Ability.OnCooldown == true)
            {
                CD2Coroutine = StartCoroutine(CooldownFill(AbilityBarScript.Ability3Overlay, Ability.Stat.Cooldown, AbilitySlot));
            }
        }

        if (AbilitySlot == 3)
        {
            SetOverlayVisibility(AbilityBarScript.Ability3Overlay, !CanActivate);
            if (Ability.UsesCooldown == true && Ability.OnCooldown == true)
            {
                CD3Coroutine = StartCoroutine(CooldownFill(AbilityBarScript.Ability3Overlay, Ability.Stat.Cooldown, AbilitySlot));
            }
        }
    }

    //Ability Cooldown Coroutine
    private IEnumerator CooldownFill(Image Overlay, int Cooldown, int AbilitySlot)
    {
        float ElapsedTime = 0.0f;
        while (ElapsedTime < Cooldown)
        {
            ElapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(ElapsedTime / Cooldown);
            Overlay.fillAmount = Mathf.Lerp(1, 0, t);
            yield return null;
        }

        CD1Coroutine = null;
        CD2Coroutine = null;
        CD3Coroutine = null;
    }

    //Ability Setup
    public void AbilityBarImageSetup(Sprite A1, Sprite A2, Sprite A3)
    {
        AbilityBarCanvas = Instantiate(AbilityBarToDraw);
        AbilityBarScript = AbilityBarCanvas.GetComponent<AbilityBar>();
        if (A1 != null)
        {
            AbilityBarScript.AbilityImage1.sprite = A1;
        }
        if (A2 != null)
        {
            AbilityBarScript.AbilityImage2.sprite = A2;
        }
        if (A3 != null)
        {
            AbilityBarScript.AbilityImage3.sprite = A3;
        }
    }

    //Sets the fill type per ability based on whether they use Cooldowns or not
    public void AbilityBarFillSetup(bool Cooldown1, bool Cooldown2, bool Cooldown3)
    {
        if (Cooldown1 == true)
        {
            SetTypeFill(AbilityBarScript.Ability1Overlay);
        }
        else
        {
            SetTypeSimple(AbilityBarScript.Ability1Overlay);
        }

        if (Cooldown2 == true)
        {
            SetTypeFill(AbilityBarScript.Ability2Overlay);
        }
        else
        {
            SetTypeSimple(AbilityBarScript.Ability2Overlay);
        }

        if (Cooldown3 == true)
        {
            SetTypeFill(AbilityBarScript.Ability3Overlay);
        }
        else
        {
            SetTypeSimple(AbilityBarScript.Ability3Overlay);
        }
    }

    private void SetOverlayVisibility(Image Overlay, bool ShouldBeActive)
    {
        Overlay.enabled = ShouldBeActive;
    }

    private void SetTypeSimple(Image Image)
    {
        Image.type = Image.Type.Simple;
    }

    private void SetTypeFill(Image Image)
    {
        Image.type = Image.Type.Filled;
        Image.fillMethod = Image.FillMethod.Radial360;
        Image.fillOrigin = 2;
        Image.fillClockwise = false;
    }
}
