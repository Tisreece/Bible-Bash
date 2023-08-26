using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : AbilityMaster
{
    [SerializeField] private SmiteZone SmiteZone;
    private GameObject SmiteZoneSpawned;
    private SmiteZone SmiteZoneScript;
    [SerializeField] private float Cooldown;
    private float CooldownRemaining;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Smite ability instantiated");
        CooldownRemaining = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        if (Time.time - CooldownRemaining >= Cooldown)
        {
            Debug.Log("Smite");
            // call spawning method
            SpawnZone();
            // start cooldown
            CooldownRemaining = Time.time;
        }
        else
        {
            Debug.Log("Smite is on cooldown");
        }
    }

    void SpawnZone()
    {
        // will need to spawn the zone on the current position of the mouse
        // identify current mouse position
        // instantiate smiteZone
        // will need to grab the smiteZone component so that we can access it's stats?
    }
}
