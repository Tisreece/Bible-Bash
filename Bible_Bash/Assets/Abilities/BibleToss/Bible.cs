using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    public float Speed = 15f;
    public Rigidbody2D rb;

    [HideInInspector]public Vector2 TargetDirection;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Thrown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Throw()
    {
        TargetDirection.Normalize();
        rb.velocity = TargetDirection * Speed;
    }
}
