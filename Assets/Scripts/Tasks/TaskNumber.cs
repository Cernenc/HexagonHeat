using Assets.Scripts.Hexagons;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Tasks
{
    public class TaskNumber : ITask
    {
        private string _selectedFields = "";
        public void Task(HexCell[] cells, HashSet<HexCell> cellsToDrop)
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
                _selectedFields += "even";
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
                _selectedFields += "uneven";
            }
            UnityEngine.Debug.Log(ToString());
        }
        public override string ToString()
        {
            return $"All {_selectedFields} fields";
        }
    }
}
