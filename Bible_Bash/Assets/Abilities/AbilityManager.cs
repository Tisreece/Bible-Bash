using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject PlayerCharacter;
    //All abilities as public
    public AbilityNames SecondarySlot;
    public AbilityNames Ability1Slot;
    public AbilityNames Ability2Slot;
    public AbilityNames CrucifixionSlot;
    //I'm not quite sure how we will approach the Crusifixion combo as there will be many ways to trigger it. We may need to sort this sparately.
    //One thing I wrote in one of the tasks is an idea that we simply have different ways to apply a mark to an enemy which will allow us to trigger the ability
    [SerializeField] private AbilityList AbilityData;

    //Abilities Equipped
    [HideInInspector] public GameObject Secondary;
    [HideInInspector] public GameObject Ability1;
    [HideInInspector] public GameObject Ability2;
    [HideInInspector] public GameObject Crucifixion;

    [HideInInspector] public AbilityMaster SecondaryScript;
    [HideInInspector] public AbilityMaster Ability1Script;
    [HideInInspector] public AbilityMaster Ability2Script;

    public HUDManager HUDManager;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacter = transform.gameObject;
        //We need to equip the abilities to the player
        EquipAbility(Ability1Slot, Ability1, out Ability1, out Ability1Script);
        EquipAbility(Ability2Slot, Ability2, out Ability2, out Ability2Script);

        TellCreateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipAbility(AbilityNames NewAbility, GameObject AbilityObject, out GameObject Ability, out AbilityMaster AbilityComponent)
    {
        //TODO Currently there is nothing to say what to do if the AbilityName is set to None
        //NewAbility is the String name of the new ability to equip that it will find in the Data Table
        //AbilityObject is the slot the GameObject will occupy
        //Ability is the new Ability Gameobject that will be assigned to the slot
        //AbilityComponent is a reference to the script itself
        AbilityMaster AbilityToEquip = null;
        AbilityStats AbilityStatToEquip = null;
        if (NewAbility != AbilityNames.None)
        {
            FindAbility(NewAbility, out AbilityToEquip, out AbilityStatToEquip);
        }
        if (AbilityToEquip == AbilityObject) //If the ability to equip is the same as what is already there it will do nothing
        {
            Ability = AbilityObject;
            AbilityComponent = Ability.GetComponent<AbilityMaster>();
            return;
        }
        else
        {
            if (AbilityObject != null) //Destroy any component already occupying that slot before adding a new one
            {
                Destroy(AbilityObject);
            }
            if (AbilityToEquip != null) //Add the component, attach it to the player then rename it
            {
                AbilityObject = Instantiate(AbilityToEquip.gameObject);
                AbilityObject.transform.SetParent(transform);
                string NewName = NewAbility.ToString();
                AbilityObject.name = NewName;
            }
            Ability = AbilityObject;
            AbilityComponent = Ability.GetComponent<AbilityMaster>();
            AbilityComponent.PlayerCharacter = PlayerCharacter; //We set the PlayerCharacter gameobject in the ability
            AbilityComponent.Stat = AbilityStatToEquip;
            return;
        }
    }

    public void UseSecondary()
    {
        print("This would be where we do secondary attacks"); //TODO
    }

    public void UseAbility1()
    {
        Ability1Script.Activate();
    }

    public void UseAbility2()
    {
        Ability2Script.Activate();
    }

    public void UseCrucify()
    {
        print("This would be where we do the Crucify combo ability"); //TODO
    }

    //This will be used to find the row in the Ability Table when applying abilities
    public void FindAbility(AbilityNames NameOfAbility, out AbilityMaster Ability, out AbilityStats AbilityStat)
    {
        AbilityListData FoundRow = null;
        Ability = null;
        AbilityStat = null;

        foreach (var row in AbilityData.ListofAbilities)
        {
            if (row.AbilityName == NameOfAbility)
            {
                FoundRow = row;
                break;
            }
        }

        if (FoundRow != null)
        {
            Ability = FoundRow.AbilityType;
            AbilityStat = FoundRow.StatType;
        }
        return;
    }

    private void TellCreateHUD()
    {
        Sprite Ability1Icon = null;
        Sprite Ability2Icon = null;
        Sprite Ability3Icon = null;
        if (SecondaryScript != null)
        {
            if (SecondaryScript.AbilityIcon != null)
            {
                Ability1Icon = SecondaryScript.AbilityIcon;
            }
        }
        if (Ability1Script != null)
        {
            if (Ability1Script.AbilityIcon != null)
            {
                Ability2Icon = Ability1Script.AbilityIcon;
            }
        }
        if (Ability2Script != null)
        {
            if (Ability2Script.AbilityIcon != null)
            {
                Ability3Icon = Ability2Script.AbilityIcon;
            }
        }
        HUDManager.AbilityBarSetup(Ability1Icon, Ability2Icon, Ability3Icon);
    }
}
