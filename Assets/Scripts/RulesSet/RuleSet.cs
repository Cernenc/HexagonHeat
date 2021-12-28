using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.RulesSet
{
    public class RuleSet
    {
        public List<IRules> Rules { get; set; }
        public HashSet<IRules> CurrentRuleSet { get; private set; }
        public List<IRules> RecentlyUsedRuleSet { get; private set; }
        public Action OnChooseRuleSet { get; set; }

        public RuleSet()
        {
            Rules = new List<IRules>();
            CurrentRuleSet = new HashSet<IRules>();
            RecentlyUsedRuleSet = new List<IRules>();
        }

        public void ShuffleRuleSet()
        {
            if (Rules.Count < 3)
            {
                return;
            }

            AddToRecentlyUsedRuleSet(Rules);
            CleanCurrentSet();

            CurrentRuleSet = ModifiedCurrentRuleSet();

            ValidateCurrentRuleSet();
        }

        private void AddToRecentlyUsedRuleSet(List<IRules> rules)
        {
            if(CurrentRuleSet.Count == 0)
            {
                return;
            }

            if (RecentlyUsedRuleSet.Count != 0)
            {
                foreach(var recentRule in RecentlyUsedRuleSet)
                {
                    rules.Add(recentRule);
                }

                RecentlyUsedRuleSet.Clear();
            }

            Random random = new Random();
            List<IRules> tempRuleSet = CurrentRuleSet.ToList();

            int randomIndex1 = random.Next(tempRuleSet.Count);
            RecentlyUsedRuleSet.Add(tempRuleSet[randomIndex1]);
            tempRuleSet.RemoveAt(randomIndex1);

            int randomIndex2 = random.Next(tempRuleSet.Count);
            RecentlyUsedRuleSet.Add(tempRuleSet[randomIndex2]);
        }

        public void CleanCurrentSet()
        {
            if(CurrentRuleSet.Count != 0)
            {
                CurrentRuleSet.Clear();
            }
        }

        private HashSet<IRules> ModifiedCurrentRuleSet()
        {
            HashSet<IRules> currentRuleSet = new HashSet<IRules>();
            Random random = new Random();
            int i = 0;
            while (i < 3)
            {
                int randomIndex = random.Next(Rules.Count);
                currentRuleSet.Add(Rules[randomIndex]);
                i++;

                if(currentRuleSet.Count != i)
                {
                    --i;
                }
            }

            return currentRuleSet;
        }

        private void ValidateCurrentRuleSet()
        {
            if (CurrentRuleSet.Count != 3)
            {
                UnityEngine.Debug.Log("Current Set: " + CurrentRuleSet.Count);
                return;
            }

            OnChooseRuleSet?.Invoke();
        }
    }
}
