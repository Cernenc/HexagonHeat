using Assets.Scripts.Hexagons;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Tasks
{
    public class TaskColor : ITask
    {
        private string _selectedCells = "";
        public void Task(HexCell[] cells, List<HexCell> cellsToDrop, ref List<HexCell> temps)
        {
            Color[] colors = new Color[3];
            int numberColors = RandomGenerator.RandomNumber(0, 3);
            int[] numbers = new int[numberColors];
            if(numbers.Length == 0)
            {
                if(cellsToDrop.Count != 0)
                {
                    var serviceEndPoints = cellsToDrop.SelectMany(t =>
                        Enumerable.Repeat(t, 2)).ToList();
                    temps = serviceEndPoints;
                }
                else
                {
                    var serviceEndPoints = cells.SelectMany(t =>
                        Enumerable.Repeat(t, 1)).ToList();
                    temps = serviceEndPoints;
                }
                _selectedCells += "N/A";
                Debug.Log(ToString());
                return;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = RandomGenerator.RandomNumber(0, ColorCheck.HexCellColors.Length);
                colors[i] = ColorCheck.HexCellColors[numbers[i]];
            }

            for(int i = 0; i < cells.Length; i++)
            {
                bool isMismatch = true;
                for (int x = 0; x < colors.Length; x++)
                {
                    if(cells[i].HexColor == colors[x])
                    {
                        isMismatch = false;
                        _selectedCells += cells[i].HexNumber;
                        break;
                    }
                }
                if (isMismatch)
                {
                    cellsToDrop.Add(cells[i]);
                }
            }
            Debug.Log(ToString());
        }

        public override string ToString()
        {
            return $"Safe: Colors {_selectedCells}";
        }
    }
}
