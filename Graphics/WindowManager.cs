using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

using ArcadiaEngine.Exceptions;

namespace ArcadiaEngine.Graphics {
    unsafe static class WindowManager {
        // Game display window
        public static Window* window { get; set; }

        public static Vector2 window_size { get; set; }

        private static void initialize_window() {
            window_size = Settings.window_size;

            GLFW.Init();

            // using OpenGL 4.6 core profile
            GLFW.WindowHint(WindowHintInt.ContextVersionMajor, 4);
            GLFW.WindowHint(WindowHintInt.ContextVersionMinor, 6);
            GLFW.WindowHint(WindowHintOpenGlProfile.OpenGlProfile, OpenGlProfile.Core);

            // focus the window and disable resize
            GLFW.WindowHint(WindowHintBool.Focused, true);
            GLFW.WindowHint(WindowHintBool.Resizable, false);

            window = GLFW.CreateWindow((int)Settings.window_size.X, (int)Settings.window_size.Y, Settings.window_name, null, null);
            if(window is null)
                throw new WindowNotCreatedError();

            // center the window on the screen
            GLFW.GetMonitorWorkarea(GLFW.GetPrimaryMonitor(), out _, out _, out int working_area_width, out int working_area_height);
            int x = (working_area_width - (int)Settings.window_size.X) / 2;
            int y = (working_area_height - (int)Settings.window_size.Y) / 2;
            GLFW.SetWindowPos(window, x, y);

            GLFW.MakeContextCurrent(window);
            GL.LoadBindings(new GLFWBindingsContext());

            //Viewport(0, 0, (int)Settings.window_size.X, (int)Settings.window_size.Y);
            // vsync
            GLFW.SwapInterval(Settings.vsync); // 0 is off, 1 is on
        }

        public static void initialize() {
            initialize_window();
        }

        public static bool window_should_close() {
            return GLFW.WindowShouldClose(window);
        }

        public static void set_scroll_callback(GLFWCallbacks.ScrollCallback onScroll) {
            GLFW.SetScrollCallback(window, onScroll);
        }

        public static void swap_buffers() {
            GLFW.SwapBuffers(window);
        }

        public static Monitor* get_current_monitor() {
            return GLFW.GetWindowMonitor(window);
        }
    }
}
