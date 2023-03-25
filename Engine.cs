using GLFW;
using ArcadiaEngine.Graphics;
// using ArcadiaEngine.Physics;
// using ArcadiaEngine.Audio;

namespace ArcadiaEngine {
    abstract class Engine {
        public virtual void run() {
            Settings.load();

            WindowManager.initialize();
            Renderer.initialize();
            initialize();

            load();

            while (!Glfw.WindowShouldClose(WindowManager.window)) {
                Timer.tick();
                update();

                Glfw.PollEvents();

                Renderer.clear_color();
                draw();
                Renderer.swap_buffers();
            }

            Settings.save();
        }

        protected abstract void initialize();
        protected abstract void load();
        protected abstract void update();
        protected abstract void draw();
    }
}
