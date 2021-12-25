using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RulesSet.Rules
{
    public class RuleDontStop : IRules
    {
        public void Rule()
        {
            UnityEngine.Debug.Log("RuleDontStop");
        }
    }
}
