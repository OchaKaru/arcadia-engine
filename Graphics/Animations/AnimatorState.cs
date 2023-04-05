using System.Collections.Generic;

namespace ArcadiaEngine.Graphics.Animations {
    internal class AnimatorState {
        private Dictionary<string, AnimationController> controllers;

        public Dictionary<string, AnimationController>.ValueCollection get_controllers() {
            return controllers.Values;
        }
    }
}
