using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleToss : AbilityMaster
{

    [SerializeField] private Bible BibleToThrow;
    private GameObject BibleThrown;
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
        BibleThrown = Instantiate(BibleToThrow.gameObject);
    }
}
