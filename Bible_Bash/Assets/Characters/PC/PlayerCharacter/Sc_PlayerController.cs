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
    private Camera PlayerCamera;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        PlayerCamera = transform.Find("DefaultCamera").gameObject.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            MoveCharacter();
        }
        
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            ZoomCamera();
        }

        if (Input.GetButtonDown("Primary")) //Melee Attack
        {
            print("This would be where we do melee attacks"); //TODO
        }

        if (Input.GetButtonDown("Secondary")) //Secondary Attack
        {
            print("This would be where we do secondary attacks"); //TODO
        }

        if (Input.GetButtonDown("Ability1")) //Ability 1
        {
            print("This would be where we do Ability 1"); //TODO
        }

        if (Input.GetButtonDown("Ability2")) //Ability 2
        {
            print("This would be where we do Ability 2"); //TODO
        }

        if (Input.GetButtonDown("Crucify")) //Crucify
        {
            print("This would be where we do the Crucify combo ability"); //TODO
        }
    }

    private void MoveCharacter()
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

    private void ZoomCamera()
    {
        float MaxZoom = 8f;
        float MinZoom = 2f;
        float CurrentZoom = PlayerCamera.orthographicSize;
        if (Input.mouseScrollDelta.y < 0) //Zoom Out
        {
            float NewZoom = CurrentZoom + CameraZoomSpeed;
            if (NewZoom > MaxZoom)
            {
                NewZoom = MaxZoom;
                PlayerCamera.orthographicSize = NewZoom;
            }
            else
            {;
                PlayerCamera.orthographicSize = NewZoom;
            }
        }
        if (Input.mouseScrollDelta.y > 0) // Zoom In
        {
            float NewZoom = CurrentZoom - CameraZoomSpeed;
            if (NewZoom < MinZoom)
            {
                NewZoom = MinZoom;
                PlayerCamera.orthographicSize = NewZoom;
            }
            else
            {
                PlayerCamera.orthographicSize = NewZoom;
            }
        }
    }
}
