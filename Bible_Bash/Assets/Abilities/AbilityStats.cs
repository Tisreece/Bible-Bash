using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityStats", menuName = "DataTables/AbilityStats")]
public class AbilityStats : ScriptableObject
{
    public float Damage;
    public float Speed;
    public float Range;
    public float Radius;
}
