using static GLFW.Glfw;

namespace ArcadiaEngine.Graphics {
    static class Timer {
        public static float delta_time { get; set; }
        public static float elapsed_time { get; set; }

        public static void tick() {
            delta_time = (float)Time - elapsed_time;
            elapsed_time = (float)Time;
        }
    }
}
