using OpenTK.Mathematics;

namespace ArcadiaEngine.Graphics.Animations {
    internal class AnimationController {
        private string controller_name;
        public bool temporary { get; }

        public int resolve(in AnimatorState current, in AnimatorState next, int size) {
            if(size == 0)
                return 0;

            int controller_value = current.get_controller(controller_name) % size;
            next.set_controller(controller_name, (controller_value + 1) % size);

            return controller_value;
        }
    }
}
