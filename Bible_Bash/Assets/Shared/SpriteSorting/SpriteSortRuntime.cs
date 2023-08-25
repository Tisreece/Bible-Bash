using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSortRuntime : MonoBehaviour
{
    public SpriteRenderer[] SpritesToSort;
    private Vector2 CurrentLocation;
    private int NewSortOrder;

    private void Update()
    {
        NewSortOrder = GetSortOrder();
        foreach (SpriteRenderer SR in SpritesToSort)
        {
            SR.sortingOrder = NewSortOrder;
        }
    }

    private int GetSortOrder()
    {
        CurrentLocation = transform.position;
        float YPositon = transform.position.y * 100;
        int NewSort = (int)Mathf.RoundToInt(YPositon);
        NewSort = -NewSort;
        return NewSort;
    }
}
