using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    [HideInInspector] public float Damage;
    [HideInInspector] public Vector2 TargetDirection;
    public SpriteRenderer DropRadiusSprite;

    public Rigidbody2D rb;
    private bool IsMoving;

    //All variable relating to calculating the distance to travel
    [HideInInspector] public float Range;
    [HideInInspector] public Vector2 StartingPosition;
    private Vector2 LastPosition;
    private Vector2 Displacement;
    private float TotalDistance;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bible Created");
        LastPosition = StartingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving == true)
        {
            CalculateDistance();
            if (TotalDistance >= Range)
            {
                Landed();
            }
        }
    }

    private void CalculateDistance()
    {
        if (LastPosition == null)
        {
            LastPosition = StartingPosition;
        }
        Vector2 CurrentPosition = transform.position;
        Displacement = CurrentPosition - LastPosition;
        float DistanceThisFrame = Displacement.magnitude;
        TotalDistance = DistanceThisFrame + TotalDistance;
        LastPosition = CurrentPosition;
    }

    private void Landed()
    {
        Debug.Log("BibleLanded");
        rb.velocity = new Vector2(0,0);
        IsMoving = false;
        DropRadiusSprite.enabled = true;
    }

    public void Throw(float Speed)
    {
        Debug.Log("Bible Thrown");
        TargetDirection.Normalize();
        rb.velocity = TargetDirection * Speed;
        IsMoving = true;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Use tags to differentiate between enemies and static objects
        // Will want to stop the bible if colliding with a wall etc.
        
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bible collided with enemy");
            EnemyController Enemy = other.GetComponent<EnemyController>();
            if (Enemy != null)
            {
                // deal damage based on Damage stat
                Enemy.Health.TakeDamage(Damage);
            }
        }
    }
}
