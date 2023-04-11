using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Graphics.Animations.Nodes {
    using ControllerDictionary = Dictionary<string, int>;

    internal abstract class AnimatorNode {
        protected AnimationController node_controller;
        protected ControllerDictionary controllers;

        public AnimatorNode(string controller_name, ControllerDictionary state_modifiers) {
            node_controller = new AnimationController(controller_name);
            controllers = state_modifiers;
        }

        public abstract TerminalNode resolve(in AnimatorState current, in AnimatorState next);
    }
}
