using Assets.Scripts.Hexagons;
using System.Collections.Generic;

namespace Assets.Scripts.Tasks
{
    public class TaskNumber : ITask
    {
        public TaskNumber()
        {
            if(_selectedFields != "")
            {
                _selectedFields = "";
            }
        }
        private string _selectedFields = "";
        public void Task(HexCell[] cells, List<HexCell> cellsToDrop, ref List<HexCell> temps)
        {
            int number = RandomGenerator.RandomNumber(0, 6); //0 => 0; 1-3 => even; 4-6 => uneven
            if (number == 0)
            {
                foreach(var cell in cells)
                {
                    if(cell.HexNumber != 0)
                    {
                        cellsToDrop.Add(cell);
                    }
                }
                _selectedFields = "Field zero";
            }
            else if (number > 0 && number < 4)
            {
                foreach(var cell in cells)
                {
                    if(cell.HexNumber % 2 != 0 || cell.HexNumber == 0)
                    {
                        cellsToDrop.Add(cell);
                    }
                }
                _selectedFields = "All even fields";
            }
            else
            {
                foreach (var cell in cells)
                {
                    if (cell.HexNumber % 2 == 0 || cell.HexNumber == 0)
                    {
                        cellsToDrop.Add(cell);
                    }
                }
                _selectedFields = "All uneven fields";
            }
            UnityEngine.Debug.Log(ToString());
        }

        public override string ToString()
        {
            return $"Safe: {_selectedFields}";
        }
    }
}
