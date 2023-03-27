using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ArcadiaEngine.Physics {
    static class Timer {
        public static float delta_time { get; set; }
        public static float elapsed_time { get; set; }

        public static void tick() {
            delta_time = (float)GLFW.GetTime() - elapsed_time;
            elapsed_time = (float)GLFW.GetTime();
        }
    }
}
