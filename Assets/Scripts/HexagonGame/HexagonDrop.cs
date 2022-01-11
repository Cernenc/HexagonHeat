using Assets.Scripts.Hexagons;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HexagonDrop
{
    public HashSet<HexCell> Drops { get; set; }
    public Action OnHexDrop { get; set; }

    public void Drop()
    {
        Debug.Log("Drop");
        foreach(var drop in Drops)
        {
            drop.gameObject.SetActive(false);
        }

        OnHexDrop.Invoke();
    }
}
