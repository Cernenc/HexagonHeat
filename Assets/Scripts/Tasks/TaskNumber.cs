using Assets.Scripts.Hexagons;
using System;
using System.Linq;

namespace Assets.Scripts.Tasks
{
    public class TaskNumber : ITask
    {
        public void Task(HexCell[] cells)
        {
            UnityEngine.Debug.Log("TaskNumber");
        }
    }
}
