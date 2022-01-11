﻿using Assets.Scripts.Hexagons;
using Assets.Scripts.Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Tasks
{
    public class TaskSystemBehaviour : MonoBehaviour
    {
        private HexagonDrop _drop = null;

        [SerializeField]
        private HexGrid _grid = null;
        private TaskSystem TaskSystem { get; set; }

        [field: SerializeField]
        private UnityEvent OnTaskChosen { get; set; }

        public GameManager gameManager { private get; set; }

        private void Start()
        {
            Setup();
        }

        public void Setup()
        {
            TaskSystem = new TaskSystem();
            TaskSystem.Grid = _grid;
            TaskSystem.OnTaskChosen += HandleChosenTask;
        }

        public void ChooseTask()
        {
            TaskSystem.ChooseTask();
        }

        private void HandleChosenTask()
        {
            _drop = gameManager.Drop;
            _drop.Drops = new HashSet<HexCell>();

            TaskSystem.Temps.ForEach(item => TaskSystem.CellsToDrop.Add(item));
            
            var duplicates = TaskSystem.CellsToDrop
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach(var duplicate in duplicates)
            {
                _drop.Drops.Add(duplicate);
            }

            Timer.TimerBehaviour timer = gameManager.Timer;
            timer.Duration = 2f;
            //timer.TimerSetup(_drop.Drop);

            OnTaskChosen.Invoke();
        }
    }
}
