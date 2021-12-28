using Assets.Scripts.Hexagons;
using System.Collections.Generic;

namespace Assets.Scripts.Tasks
{
    public class TaskNumber : ITask
    {
        private string _selectedFields = "";
        public void Task(HexCell[] cells, List<HexCell> cellsToDrop, ref List<HexCell> temps)
        {
            int number = RandomGenerator.RandomNumber(0, 2);
            if (number == 0)
            {
                foreach(var cell in cells)
                {
                    if(cell.HexNumber != 0)
                    {
                        cellsToDrop.Add(cell);
                    }
                }
                _selectedFields = "zero";
            }
            else if (number == 2)
            {
                foreach(var cell in cells)
                {
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
            return $"Safe: All {_selectedFields} fields";
        }
    }
}
