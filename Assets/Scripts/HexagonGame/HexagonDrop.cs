using Assets.Scripts.Hexagons;
using System.Collections.Generic;
using UnityEngine;

public class HexagonDrop
{
    public List<HexCell> Drops { get; set; }
    public void Drop()
    {
        Debug.Log("Drop");
        foreach(var drop in Drops)
        {
            drop.gameObject.SetActive(false);
        }
    }
}
