using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmiteZone : MonoBehaviour
{

    public float DamageRadiusCollision;
    public float DamageRadiusSprite;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Smite Created");
        // call CreateZone
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO - Slowing effect within the AoE prior to damage?
    void CreateZone()
    {
        // turn on sprite and collider
        // wait 1 second
        // spawn lightning sprite
        // wait 0.5 seconds
        // call DealDamage
    }

    void DealDamage()
    {
        // deal AoE damage to enemies in the radius
    }
}
