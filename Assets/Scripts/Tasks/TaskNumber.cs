using Assets.Scripts.Hexagons;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Tasks
{
    public class TaskNumber : ITask
    {
        public void Task(HexCell[] cells, List<HexCell> cellsToDrop)
        {
            Random random = new Random();
            bool isEven = random.Next(1, 2) == 1;
            UnityEngine.Debug.Log($"is even: {isEven}");
            
            if (isEven)
            {
                foreach(var cell in cells)
                {
                    if(cell.HexNumber == 0)
                    {
                        continue;
                    }
                    if(cell.HexNumber % 2 != 0)
                    {
                        cellsToDrop.Add(cell);
                    }
                }
            }
            else
            {
                foreach (var cell in cells)
                {
                    if(cell.HexNumber == 0)
                    {
                        continue;
                    }
                    if (cell.HexNumber % 2 == 0)
                    {
                        cellsToDrop.Add(cell);
                    }
                }
            }

            foreach(var task in cellsToDrop)
            {
                UnityEngine.Debug.Log(task.HexNumber);
            }
        }
    }
}
