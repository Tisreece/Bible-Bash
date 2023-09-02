using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMaster : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public AbilityStats Stat;
    [HideInInspector] public bool CanActivate;

    public Sprite AbilityIcon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Activate()
    {
        Debug.Log("Ability Activated");
    }

    public virtual bool CheckCanActivate()
    {
        CanActivate = true;
        return CanActivate; //This is placeholder and should be overwritten in the ability script
    }
}
