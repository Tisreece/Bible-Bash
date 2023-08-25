using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    [HideInInspector] public float Damage;
    [HideInInspector] public Vector2 TargetDirection;
    [HideInInspector] public BibleToss BibleTossOrigin;

    //Inactive until dropped
    public SpriteRenderer DropRadiusSprite;
    public CapsuleCollider2D DropRadiusCollider;

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
        DropRadiusCollider.enabled = true;
    }

    public void Throw(float Speed)
    {
        Debug.Log("Bible Thrown");
        TargetDirection.Normalize();
        rb.velocity = TargetDirection * Speed;
        IsMoving = true;
    }

    public void Pickup()
    {
        BibleTossOrigin.PickupBible();
        Destroy(this.gameObject);
    }
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        //TODO Will want to stop the bible if colliding with a wall etc.

        ObjectTags ObjectTagComponent = collider.GetComponent<ObjectTags>();

        if (ObjectTagComponent != null)
        {
            if (ObjectTagComponent.Characters.Contains(CharacterTags.Enemy))
            {
                Debug.Log("Bible collided with enemy");
                EnemyController Enemy = collider.GetComponent<EnemyController>();
                if (Enemy != null)
                {
                    // deal damage based on Damage stat
                    Enemy.Health.TakeDamage(Damage);
                }
            }

            if (ObjectTagComponent.Characters.Contains(CharacterTags.Player) && IsMoving == false)
            {
                Pickup();
            }
        }
    }
}
