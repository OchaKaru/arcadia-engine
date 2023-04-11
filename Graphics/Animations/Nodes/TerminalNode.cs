using System.Collections.Generic;

using OpenTK.Mathematics;

namespace ArcadiaEngine.Graphics.Animations.Nodes {
    using ControllerDictionary = Dictionary<string, int>;

    internal class TerminalNode : AnimatorNode {
        private List<Frame> frames;

        public TerminalNode(string controller_name, ControllerDictionary state_modifiers, params Frame[] frames_to_add) : base(controller_name, state_modifiers) {
            frames = new List<Frame>();

            foreach(var frame in frames_to_add)
                frames.Add(frame);
        }

        public override TerminalNode resolve(in AnimatorState current, in AnimatorState next) {
            next.add_controller(controllers);
            return this;
        }

        public Vector2 get_frame(in AnimatorState current, in AnimatorState next) {
            Frame next_frame = frames[node_controller.resolve(current, next, frames.Count)];
            next.add_controller(next_frame.controllers);
            return next_frame.frame_coordinates;
        }
    }
}
