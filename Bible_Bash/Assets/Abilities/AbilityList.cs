using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListOfAbilities" , menuName = "DataTables/ListOfAbilities")]
public class AbilityList : ScriptableObject
{
    public AbilityListData[] ListofAbilities;
}
