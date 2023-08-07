using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleToss : AbilityMaster
{
    [SerializeField] private Bible BibleToThrow;
    private GameObject BibleThrown;
    private Bible BibleScript;

    private Vector2 TargetDirection;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BibleToss ability instantiated");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        Debug.Log("BibleTossActivated");
        TargetDirection = FindDirection();

        BibleThrown = Instantiate(BibleToThrow.gameObject, PlayerCharacter.transform.position, PlayerCharacter.transform.rotation);
        BibleScript = BibleThrown.GetComponent<Bible>();
        BibleScript.TargetDirection = TargetDirection;
        BibleScript.Throw();
    }

    private Vector2 FindDirection()
    {
        Vector2 Direction;
        Vector3 CursorPositionOnScreen = Input.mousePosition;
        Vector3 CursorPosition = Camera.main.ScreenToWorldPoint(CursorPositionOnScreen);
        CursorPosition.z = 0;

        Direction = CursorPosition - PlayerCharacter.transform.position;
        return Direction;
    }
}
