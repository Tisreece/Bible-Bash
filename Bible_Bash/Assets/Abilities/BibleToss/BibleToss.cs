using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleToss : AbilityMaster
{
    [SerializeField] private Bible BibleToThrow;
    private GameObject BibleThrown;
    private Bible BibleScript;

    private Vector2 TargetDirection;

    //These are all the bools that will dictate whether or not the Ability can be activated
    [HideInInspector] public bool IsEquipped = true;

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
        CanActivate = CheckCanActivate();
        if (CanActivate == true)
        {
            Debug.Log("BibleTossActivated");
            TargetDirection = FindDirection();
            SpawnBible();
            IsEquipped = false;
            BibleScript.Throw(Stat.Speed);
            UpdateIconHUD();
        }
        else
        {
            Debug.Log("BibleTossCannotBeActivated");
        }
        
    }
    private void SetBibleStats(Bible BibleThrown, Vector2 StartingPosition)
    {
        BibleThrown.Damage = Stat.Damage;
        BibleThrown.Range = Stat.Range;
        BibleThrown.StartingPosition = StartingPosition;
        BibleThrown.BibleTossOrigin = this;
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

    private void SpawnBible()
    {
        Vector2 StartingPosition = PlayerCharacter.transform.position; //This may be overengineering it slightly, I think we could just set the starting position in the bible script itself
        BibleThrown = Instantiate(BibleToThrow.gameObject, StartingPosition, PlayerCharacter.transform.rotation);
        BibleScript = BibleThrown.GetComponent<Bible>();
        BibleScript.TargetDirection = TargetDirection;
        SetBibleStats(BibleScript, StartingPosition);
    }

    public void PickupBible()
    {
        IsEquipped = true;
        UpdateIconHUD();
    }

    public override bool CheckCanActivate()
    {
        bool CheckResult = false;
        CheckResult = IsEquipped;
        return CheckResult;
    }
}
