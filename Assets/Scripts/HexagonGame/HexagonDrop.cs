using Assets.Scripts.Hexagons;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HexagonDrop
{
    public HashSet<HexCell> Drops { get; set; }
    public UnityEvent OnHexDrop { get; set; }
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
