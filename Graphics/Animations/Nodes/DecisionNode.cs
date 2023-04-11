using System.Collections.Generic;

namespace ArcadiaEngine.Graphics.Animations.Nodes {
    using ControllerDictionary = Dictionary<string, int>;

    internal class DecisionNode : AnimatorNode {
        private List<AnimatorNode> nodes;

        public DecisionNode(string controller_name, ControllerDictionary state_modifiers, params AnimatorNode[] nodes_to_add) : base(controller_name, state_modifiers) {
            nodes = new List<AnimatorNode>();

            foreach(AnimatorNode node in nodes_to_add)
                nodes.Add(node);
        }

        public override TerminalNode resolve(in AnimatorState current, in AnimatorState next) {
            next.add_controller(controllers);
            return nodes[node_controller.resolve(current, next, nodes.Count)].resolve(current, next);
        }
    }
}
