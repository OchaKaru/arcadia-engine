using GLFW;

namespace ArcadiaEngine.Graphics {
    abstract class Renderer { // Game Renderer
        public void run() {
            _initialize();
            WindowManager.initialize();

            _load();

            while (!Glfw.WindowShouldClose(WindowManager.window)) {
                Timer.delta_time = (float)Glfw.Time - Timer.elapsed_time;
                Timer.elapsed_time = (float)Glfw.Time;

                _update();

                Glfw.PollEvents();

                _draw();
            }

        }

        protected abstract void _initialize();
        protected abstract void _load();
        protected abstract void _update();
        protected abstract void _draw();

    }
}
