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

    public void AbilityBarSetup(Sprite A1, Sprite A2, Sprite A3)
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
}
