using OpenTK.Windowing.GraphicsLibraryFramework;

using ArcadiaEngine.Graphics;
using ArcadiaEngine.Physics;

namespace ArcadiaEngine {
	abstract class Engine {
        public virtual void run() {
            Settings.load();

            WindowManager.initialize();
            Renderer.initialize();
            initialize();
            load();

            while(!WindowManager.window_should_close()) {
                Timer.tick();
                update();

                GLFW.PollEvents();

                Renderer.clear_color();
                draw();
                WindowManager.swap_buffers();
            }

            Settings.save();
        }

        protected abstract void initialize();
        protected abstract void load();
        protected abstract void update();
        protected abstract void draw();
    }
}
