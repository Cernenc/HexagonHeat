using Assets.Scripts.Hexagons;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HexagonGameBehaviour
{
    public HashSet<HexCell> FieldsToDrop { get; set; }
    public Action OnHexDrop { get; set; }

    public void Drop()
    {
        Debug.Log("Drop");
        foreach(var drop in FieldsToDrop)
        {
            drop.gameObject.SetActive(false);
        }

        OnHexDrop.Invoke();
    }
}
