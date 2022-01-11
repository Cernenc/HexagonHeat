using Assets.Scripts.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Tasks
{
    public class TaskSystem
    {
        public HexGrid Grid { private get; set; }
        public List<ITask> Tasks { get; set; }
        public List<HexCell> CellsToDrop { get; set; }
        public List<HexCell> Temps;
        public Action OnTaskChosen { get; set; }
        public TaskSystem()
        {
            Tasks = new List<ITask>();
            Tasks.Add(new TaskNumber());
            Tasks.Add(new TaskColor());
            Tasks.Add(new TaskZero());
            CellsToDrop = new List<HexCell>();
            Temps = new List<HexCell>();
        }

        public void ChooseTask()
        {
            if (Tasks.Count < 3)
            {
                return;
            }

            var chosenTasks = ModifiedTasks();
            foreach (var task in chosenTasks)
            {
                task.Task(Grid.Cells, CellsToDrop, ref Temps);
            }
            OnTaskChosen?.Invoke();
        }

        private HashSet<ITask> ModifiedTasks()
        {
            HashSet<ITask> chosenTasks = new HashSet<ITask>();
            int i = 0;
            while(i < 3)
            {
                int randomIndex = RandomGenerator.RandomNumber(0, Tasks.Count);
                chosenTasks.Add(Tasks[randomIndex]);
                i++;

                if(chosenTasks.Count != i)
                {
                    --i;
                }
            }

            return chosenTasks;
        }
    }
}
