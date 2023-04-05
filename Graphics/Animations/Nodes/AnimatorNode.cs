using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Graphics.Animations.Nodes {
    internal abstract class AnimatorNode {
        private Dictionary<string, AnimationController> controllers;

        public abstract TerminalNode resolve();
    }
}
