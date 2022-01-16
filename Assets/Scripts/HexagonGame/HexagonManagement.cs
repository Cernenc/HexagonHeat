using Assets.Scripts.Hexagons;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HexagonManagement
{
    private HashSet<HexCell> FieldsToDrop { get; set; }
    public Action OnHexDrop { get; set; }

    public HexagonManagement()
    {
        FieldsToDrop = new HashSet<HexCell>();
    }

    public void Drop()
    {
        Debug.Log("Drop");
        foreach(var drop in FieldsToDrop)
        {
            drop.gameObject.SetActive(false);
        }

        OnHexDrop?.Invoke();
    }
    public void AddFieldsToDrop(IEnumerable<HexCell> hexCells)
    {
        foreach(var cell in hexCells)
        {
            FieldsToDrop.Add(cell);
        }
    }

    public void ResetPlatforms()
    {
        foreach(var drop in FieldsToDrop)
        {
            drop.gameObject.SetActive(true);
        }
    }
}
