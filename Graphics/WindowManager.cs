using System.Numerics;
using System.Drawing;

using GLFW;
using static GLFW.Glfw;
using static OpenGL.Gl;

using Hint = GLFW.Hint;

namespace ArcadiaEngine.Graphics {
    static class WindowManager {
        // Game display window
        public static Window window { get; set; }
        public static Vector2 window_size { get; set; }

        // Debug simulation window
        public static Window debug { get; set; }
        public static Vector2 debug_size { get; set; }

        private static void initialize_window() {
            //window_size.Add(title, new Vector2(width, height));
            window_size = Settings.window_size;

            Init();

            // using OpenGL 4.6 core profile
            WindowHint(Hint.ContextVersionMajor, 4);
            WindowHint(Hint.ContextVersionMinor, 6);
            WindowHint(Hint.OpenglProfile, Profile.Core);

            // focus the window and disable resize
            WindowHint(Hint.Focused, true);
            WindowHint(Hint.Resizable, false);

            window = CreateWindow((int)Settings.window_size.X, (int)Settings.window_size.Y, Settings.window_name, Monitor.None, Window.None);
            if(window == Window.None) {
                // somethign went wrong
                return;
            }

            // center the window on the screen
            Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
            int x = (screen.Width - (int)Settings.window_size.X) / 2;
            int y = (screen.Height - (int)Settings.window_size.Y) / 2;
            SetWindowPosition(window, x, y);

            Initialize();
            MakeContextCurrent(window);

            Viewport(0, 0, (int)Settings.window_size.X, (int)Settings.window_size.Y);
            // vsync
            SwapInterval(Settings.vsync); // 0 is off, 1 is on
        }

        public static void initialize() {
            initialize_window();
        }

        public static Monitor get_current_monitor() {
            return GetWindowMonitor(window);
        }
    }
}
