using OpenTK.Windowing.GraphicsLibraryFramework;

using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics;
using ArcadiaEngine.Physics;

namespace ArcadiaEngine {
    public abstract class Engine {
        public virtual void run() {
            Settings.load();

            WindowManager.initialize();
            GraphicsEngine.initialize();
            initialize();

            load();

            while(!WindowManager.window_should_close()) {
                Timer.tick();

                update();
                GraphicsEngine.update_camera();

                GLFW.PollEvents();

                GraphicsEngine.clear_color();
                draw();
                GraphicsEngine.render();

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
