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
    private GameObject Secondary;
    private GameObject Ability1;
    private GameObject Ability2;
    private GameObject Crucifixion;

    private AbilityMaster Ability1Script;
    private AbilityMaster Ability2Script;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacter = transform.gameObject;
        //We need to equip the abilities to the player
        EquipAbility(Ability1Slot, Ability1, out Ability1, out Ability1Script);
        EquipAbility(Ability2Slot, Ability2, out Ability2, out Ability2Script);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipAbility(AbilityNames NewAbility, GameObject AbilityObject, out GameObject Ability, out AbilityMaster AbilityComponent)
    {
        //TODO Currently there is nothing to say what to do if the AbilityName is set to None
        AbilityMaster Ability1ToEquip = null;
        if (NewAbility != AbilityNames.None)
        {
            Ability1ToEquip = FindAbility(NewAbility);
        }
        if (Ability1ToEquip == AbilityObject) //If the ability to equip is the same as what is already there it will do nothing
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
            if (Ability1ToEquip != null)
            {
                AbilityObject = Instantiate(Ability1ToEquip.gameObject);
                AbilityObject.transform.SetParent(transform);
                string NewName = NewAbility.ToString();
                AbilityObject.name = NewName;
            }
            Ability = AbilityObject;
            AbilityComponent = Ability.GetComponent<AbilityMaster>();
            AbilityComponent.PlayerCharacter = PlayerCharacter; //We set the PlayerCharacter gameobject in the ability
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
        print("This would be where we do Ability 2"); //TODO
    }

    public void UseCrucify()
    {
        print("This would be where we do the Crucify combo ability"); //TODO
    }

    //This will be used to find the row in the Ability Table when applying abilities
    public AbilityMaster FindAbility(AbilityNames NameOfAbility)
    {
        AbilityListData FoundRow = null;
        AbilityMaster Ability = null;

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
        }

        return Ability;
    }
}
