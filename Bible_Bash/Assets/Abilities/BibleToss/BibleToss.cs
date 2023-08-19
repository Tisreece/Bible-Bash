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

        Vector2 StartingPosition = PlayerCharacter.transform.position; //This may be overengineering it slightly, I think we could just set the starting position in the bible script itself
        BibleThrown = Instantiate(BibleToThrow.gameObject, StartingPosition, PlayerCharacter.transform.rotation);
        BibleScript = BibleThrown.GetComponent<Bible>();
        BibleScript.TargetDirection = TargetDirection;
        SetBibleStats(BibleScript, StartingPosition);
        BibleScript.Throw(Stat.Speed);
    }
    private void SetBibleStats(Bible BibleThrown, Vector2 StartingPosition)
    {
        BibleThrown.Damage = Stat.Damage;
        BibleThrown.Range = Stat.Range;
        BibleThrown.StartingPosition = StartingPosition;
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
