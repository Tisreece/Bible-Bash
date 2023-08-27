using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : AbilityMaster
{
    [SerializeField] private SmiteZone SmiteZone;
    private GameObject SmiteZoneSpawned;
    private SmiteZone SmiteZoneScript;
    [SerializeField] private float Cooldown;
    private float CooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Smite ability instantiated");
        CooldownTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!CheckCanActivate())
        {
            CooldownTimer -= Time.deltaTime;
        }
    }
    public override void Activate()
    {
        if (CheckCanActivate())
        {
            Debug.Log("Smite");
            // call spawning method
            SpawnZone();
            // start cooldown
            CooldownTimer = Cooldown;
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

    public override bool CheckCanActivate()
    {
        // check that the cooldown timer is <= to 0, set to 0 and return true
        if (CooldownTimer <= 0.0f)
        {
            CooldownTimer = 0.0f;
            return true;
        }
        else
        {
            return false;
        }
    }
}
