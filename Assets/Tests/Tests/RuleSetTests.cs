using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.RulesSet;
using Assets.Scripts.RulesSet.Rules;
using NUnit.Framework;
namespace Tests
{
    public class RuleSetTests
    {
        [Test]
        public void RuleSetAddsToCurrentRuleSet()
        {
            RuleSet ruleSet = new RuleSet();
            ruleSet.Rules.Add(new RuleNoJump());
            ruleSet.Rules.Add(new RuleDontStop());
            ruleSet.Rules.Add(new Rule3());
            ruleSet.Rules.Add(new Rule4());
            ruleSet.Rules.Add(new Rule5());

            ruleSet.ShuffleRuleSet();

            Assert.AreEqual(3, ruleSet.CurrentRuleSet.Count);
        }

        [Test]
        public void DistinctRulesInCurrentRuleSet()
        {
            RuleSet ruleSet = new RuleSet();
            ruleSet.Rules.Add(new RuleNoJump());
            ruleSet.Rules.Add(new RuleDontStop());
            ruleSet.Rules.Add(new Rule3());
            ruleSet.Rules.Add(new Rule4());
            ruleSet.Rules.Add(new Rule5());

            ruleSet.ShuffleRuleSet();

            //Assert.AreEqual(0, numberOfDuplicates);
        }
    }
}
