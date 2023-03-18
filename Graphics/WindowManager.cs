using GLFW;
using ArcadiaEngine.Graphics.OpenGL;
using System.Numerics;
using System.Drawing;

namespace ArcadiaEngine.Graphics {
    static class WindowManager {
        // Game display window
        public static Window window { get; set; }
        public static Vector2 window_size { get; set; }

        // Debug simulation window
        public static Window debug { get; set; }
        public static Vector2 debug_size { get; set; }

        private static void _initialize_window() {
            //window_size.Add(title, new Vector2(width, height));
            window_size = Settings.window_size;

            Glfw.Init();

            // using OpenGL 3.3 core profile
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);

            // focus the window and disable resize
            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, false);

            window = Glfw.CreateWindow((int)Settings.window_size.X, (int)Settings.window_size.Y, Settings.window_name, Monitor.None, Window.None);
            if(window == Window.None) {
                // somethign went wrong
                return;
            }

            // center the window on the screen
            Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
            int x = (screen.Width - (int)Settings.window_size.X) / 2;
            int y = (screen.Height - (int)Settings.window_size.Y) / 2;
            Glfw.SetWindowPosition(window, x, y);

            Glfw.MakeContextCurrent(window);
            GL.Import(Glfw.GetProcAddress);

            GL.glViewport(0, 0, (int)Settings.window_size.X, (int)Settings.window_size.Y);
            // vsync
            Glfw.SwapInterval(Settings.vsync); // 0 is off, 1 is on
        }

        public static void initialize() {
            _initialize_window();
        }


    }
}
