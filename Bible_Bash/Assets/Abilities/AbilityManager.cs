using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

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

    // Start is called before the first frame update
    void Start()
    {
        //We need to equip the abilities to the player
        EquipAbility1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipAbility1()
    {
        AbilityMaster Ability1ToEquip = null;
        if (Ability1Slot != AbilityNames.None)
        {
            Ability1ToEquip = FindAbility(Ability1Slot);
        }
        if (Ability1ToEquip != null)
        {
            Ability1 = Instantiate(Ability1ToEquip.gameObject);
            Ability1.transform.SetParent(transform);
        }
        
    }

    public void EquipAbility2()
    {

    }

    public void UseSecondary()
    {
        print("This would be where we do secondary attacks"); //TODO
    }

    public void UseAbility1()
    {
        print("This would be where we do Ability 1"); //TODO
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
