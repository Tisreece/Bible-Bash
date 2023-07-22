using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PlayerController : MonoBehaviour
{

    //Character Movement
    public float MovementSpeed = 5f;
    Rigidbody2D rbody;

    //Camera
    public float CameraZoomSpeed = 0.5f;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Vector2 CurrentPosition = rbody.position;
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        Vector2 InputVector = new Vector2(HorizontalInput, VerticalInput);
        InputVector = Vector2.ClampMagnitude(InputVector, 1); // This makes diagonal movement equal speed
        Vector2 Movement = InputVector * MovementSpeed;
        Vector2 NewPosition = CurrentPosition + Movement * Time.fixedDeltaTime;
        rbody.MovePosition(NewPosition);
    }
}
