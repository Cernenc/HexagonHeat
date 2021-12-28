using Assets.Scripts.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tasks
{
    public class TaskColor : ITask
    {
        private string _selectedCells = "";
        public void Task(HexCell[] cells, HashSet<HexCell> cellsToDrop)
        {
            Random random;
            int[] randomColorIndeces = new int[3];
            for(int i = 0; i<3; i++)
            {
                random = new Random();
                randomColorIndeces[i] = random.Next(0, ColorCheck.HexCellColors.Length);
            }
            for(int i = 0; i < cells.Length; i++)
            {
                for(int j = 0; j < randomColorIndeces.Length; j++)
                {
                    if (cells[i].HexColor.Equals(ColorCheck.HexCellColors[randomColorIndeces[j]].ToString()))
                    {
                        cellsToDrop.Add(cells[i]);
                        _selectedCells += cells[i].HexColor.ToString() + " ";
                    }
                }
            }

            UnityEngine.Debug.Log(ToString());
        }

        public override string ToString()
        {
            return $"Colors {_selectedCells}";
        }
    }
}
