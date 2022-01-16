namespace Assets.Scripts.RulesSet.Rules
{
    public class RuleDontStop : IRules
    {
        public void Rule()
        {
            UnityEngine.Debug.Log("RuleDontStop");
            RulesRestrict.HasConstantMove = true;
        }
    }
}
