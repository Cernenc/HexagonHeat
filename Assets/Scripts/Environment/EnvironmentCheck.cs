using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Environment
{
    public class EnvironmentCheck
    {
        private bool _isGrounded = false;

        public float GroundDistance { get; } = 0.4f;
    }
}
