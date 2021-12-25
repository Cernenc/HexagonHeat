using Assets.Scripts.RulesSet.Rules;
using Assets.Scripts.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.RulesSet
{
    public class RuleSetBehaviour : MonoBehaviour
    {
        [SerializeField]
        private TaskSystemBehaviour _taskSystem = null;
        private RuleSet RuleSet { get; set; }

        [field: SerializeField]
        private UnityEvent OnChooseRuleSet { get; set; }

        private void Start()
        {
            RuleSet = new RuleSet();
            RuleSet.Rules.Add(new RuleNoJump());
            RuleSet.Rules.Add(new RuleDontStop());
            RuleSet.Rules.Add(new Rule3());
            RuleSet.Rules.Add(new Rule4());
            RuleSet.Rules.Add(new Rule5());

            RuleSet.OnChooseRuleSet += HandleChooseRuleSet;
            ShuffleAndRun();
        }

        private void HandleChooseRuleSet()
        {
            foreach (var rule in RuleSet.CurrentRuleSet)
            {
                rule.Rule();
            }

            Timer.TimerBehaviour timer = FindObjectOfType<Timer.TimerBehaviour>();
            timer.Duration = 3f;
            timer.TimerSetup();
            timer.OnTimerEnd = new UnityEvent();
            timer.OnTimerEnd.RemoveAllListeners();
            timer.OnTimerEnd.AddListener(_taskSystem.ChooseTask);
            OnChooseRuleSet.Invoke();
        }

        public void ShuffleAndRun()
        {
            RuleSet.ShuffleRuleSet();
        }
    }
}
