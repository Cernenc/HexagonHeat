using Assets.Scripts.Hexagons;
using System.Collections.Generic;

namespace Assets.Scripts.Tasks
{
    public interface ITask
    {
        void Task(HexCell[] cells, List<HexCell> taskCells);
    }
}
