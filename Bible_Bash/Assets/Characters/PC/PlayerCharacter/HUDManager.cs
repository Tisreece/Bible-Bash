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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Relates to the Ability Bar
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

    public void UpdateAbilityIcon(int AbilitySlot, bool CanActivate)
    {
        if (AbilitySlot == 1)
        {

        }

        if (AbilitySlot == 2)
        {
            if (CanActivate == true)
            {
                AbilityBarScript.Ability2Overlay.enabled = false;
            }

            else
            {
                AbilityBarScript.Ability2Overlay.enabled = true;
            }
        }

        if (AbilitySlot == 3)
        {

        }
    }

    private void SetTypeSimple(Image Image)
    {
        Image.type = Image.Type.Simple;
    }

    private void SetTypeFill(Image Image)
    {
        Image.type = Image.Type.Filled;
        Image.fillMethod = Image.FillMethod.Radial360;
    }
}
