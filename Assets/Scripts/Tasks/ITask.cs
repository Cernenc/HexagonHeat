using Assets.Scripts.Hexagons;

namespace Assets.Scripts.Tasks
{
    public interface ITask
    {
        void Task(HexCell[] cells);
    }
}
