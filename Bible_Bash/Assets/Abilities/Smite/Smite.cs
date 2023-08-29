using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : AbilityMaster
{
    [SerializeField] private SmiteZone SmiteZone;
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
        // create empty reference for object
        SmiteZone SmiteZoneInstance;
        // identify current mouse position
        Vector2 mousePosition = Input.mousePosition;
        // Convert mouse position to world space
        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // Instantiate the SmiteZone prefab at the spawn position
        SmiteZoneInstance = Instantiate(SmiteZone.gameObject, spawnPosition, Quaternion.identity).GetComponent<SmiteZone>();
        SetStats(SmiteZoneInstance);
        // Call the CreateZone method on the SmiteZone component
        SmiteZoneInstance.CreateZone();
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
    private void SetStats(SmiteZone SmiteZone)
    {
        SmiteZone.Damage = Stat.Damage;
    }
}
