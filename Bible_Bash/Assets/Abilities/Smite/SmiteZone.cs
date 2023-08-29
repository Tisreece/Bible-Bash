using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmiteZone : MonoBehaviour
{
    [HideInInspector] public float Damage;
    public float DamageRadiusCollision;
    public float DamageRadiusSprite;
    public float ZoneTimer;
    public float LightningTimer;
    public SpriteRenderer RadiusSprite;
    public SpriteRenderer LightningSprite;
    public CircleCollider2D RadiusCollider;
    private List<GameObject> enemiesInRange = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Smite Created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D enemy) 
    {
        if (enemy.CompareTag("Enemy"))
        {
            enemiesInRange.Add(enemy.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D enemy) 
    {
        if (enemy.CompareTag("Enemy"))
        {
            enemiesInRange.Add(enemy.gameObject);            
        }
    }

    // TODO - Slowing effect within the AoE prior to damage?
    public void CreateZone()
    {
        // turn on sprite and collider
        Debug.Log("Test");
        RadiusSprite.enabled = true;
        RadiusCollider.enabled = true;
        StartCoroutine(ActivateZone());
    }

    private IEnumerator ActivateZone()
    {
        yield return new WaitForSeconds(ZoneTimer);
        LightningSprite.enabled = true;
        yield return new WaitForSeconds(LightningTimer);
        DealDamage();
        LightningSprite.enabled = false;
        RadiusSprite.enabled = false;
    }

    private void DealDamage()
    {
        // deal AoE damage to enemies in the radius

        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
        {
            EnemyController enemy = enemiesInRange[i].GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.Health.TakeDamage(Damage);
            }
            // Remove enemy from list
            enemiesInRange.RemoveAt(i);
        }
    }
}
