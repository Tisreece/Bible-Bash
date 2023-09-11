using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : AbilityMaster
{
    [SerializeField] private SmiteZone SmiteZone;

    private void Start()
    {
        Debug.Log("Smite ability instantiated");
    }
    public override void Activate()
    {
        if (CheckCanActivate())
        {
            Debug.Log("Smite Activated");

            SpawnZone();
            StartCoroutine(StartCooldown(Stat.Cooldown));
        }
        else
        {
            Debug.Log("Smite cannot be activated");
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
        bool CheckResult = false;
        CheckResult = !OnCooldown;
        return CheckResult;
    }
    private void SetStats(SmiteZone SmiteZone)
    {
        SmiteZone.Damage = Stat.Damage;
    }
}
