﻿using Assets.Scripts.Hexagons;
using Assets.Scripts.Players.Interfaces;
using Assets.Scripts.RulesSet;
using Assets.Scripts.Tasks;
using Assets.Scripts.Timer;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Managers
{
    public class GameManager : GameBehaviour
    {
        [field: SerializeField]
        private RuleSetBehaviour RuleSet { get; set; }

        [field: SerializeField]
        private TaskSystemBehaviour TaskSystem { get; set; }

        [field: SerializeField]
        public HexGrid Grid { get; set; }

        public HexagonManagement Hex { get; set; }
        public TimerBehaviour Timer { get; private set; }
        public List<IPlayer> TotalNumberOfFallenPlayers { get; set; }

        public void Start()
        {
            TotalNumberOfFallenPlayers = new List<IPlayer>();
            Timer = FindObjectOfType<TimerBehaviour>();
            RuleSet.gameManager = this;
            TaskSystem.gameManager = this;
            SetHex();
            NewMatch();
        }

        private void SetHex()
        {
            Hex = new HexagonManagement();
            Hex.OnHexDrop += CheckLastPlayerRemaining;
        }

        private void NewMatch()
        {
            RuleSet.Shuffle();
        }

        private void NewRound()
        {
            SetHex();
            Hex.ResetPlatforms();

            TaskSystem.Setup();
            SetTimer(2f, TaskSystem.ChooseTask);
        }

        private void SetTimer(float duration, UnityAction action)
        {
            Timer.RemoveListeners();
            Timer.Duration = duration;
            Timer.TimerSetup(action);
        }

        private void CheckLastPlayerRemaining()
        {
            if(TotalNumberOfFallenPlayers.Count == 1)
            {
                EndMatch();
                return;
            }

            NextRound();
        }

        private void EndMatch()
        {
            //distribute points to player
            //go to new match
            Debug.Log("End");

            Hex.ResetPlatforms();
            SetTimer(3f, NewMatch);
        }

        public void HandleFallenPlayer(IPlayer player)
        {
            TotalNumberOfFallenPlayers.Add(player);
            CheckLastPlayerRemaining();
        }

        private void NextRound()
        {
            Timer.Duration = 5f;
            Timer.TimerSetup(NewRound);
        }
    }
}
