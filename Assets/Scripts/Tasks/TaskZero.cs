using Assets.Scripts.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tasks
{
    public class TaskZero : ITask
    {
        public void Task(HexCell[] cells, List<HexCell> taskCells)
        {
            UnityEngine.Debug.Log("Zero Task");
        }
    }
}
