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
        public Action OnChooseTask { get; set; }
        public TaskSystem()
        {
            Tasks = new List<ITask>();
            Tasks.Add(new TaskNumber());
            Tasks.Add(new TaskColor());
            Tasks.Add(new TaskZero());
        }

        public void ChooseTask()
        {
            if (Tasks.Count < 3)
            {
                return;
            }

            var chosenTasks = ModifiedTasks();
            //chosenTasks.First().Task(Grid.Cells);

            OnChooseTask?.Invoke();
        }

        private HashSet<ITask> ModifiedTasks()
        {
            HashSet<ITask> chosenTasks = new HashSet<ITask>();
            Random random = new Random();
            int randomIndex = random.Next(Tasks.Count);
            chosenTasks.Add(Tasks[randomIndex]);

            return chosenTasks;
        }
    }
}
