using System.Numerics;

using GLFW;
using static GLFW.Glfw;

namespace ArcadiaEngine.Graphics {
    class Camera {
        public Vector2 focus_position { get; set; }
        public float zoom { get; set; }

        private double _scroll_delta = 0;

        private MouseCallback onScroll;

    public Camera(Vector2 initial_focus_position, float initial_zoom) {
            focus_position = initial_focus_position;
            zoom = initial_zoom;

            onScroll = (Window, x, y) => {
                _scroll_delta = y;
            };

            SetScrollCallback(WindowManager.window, onScroll);
        }

        public Matrix4x4 get_projection_matrix() {
            float left = focus_position.X - WindowManager.window_size.X / 2f;
            float right = focus_position.X + WindowManager.window_size.X / 2f;
            float bottom = focus_position.Y + WindowManager.window_size.Y / 2f;
            float top = focus_position.Y - WindowManager.window_size.Y / 2f;

            Matrix4x4 orthographic_matrix = Matrix4x4.CreateOrthographicOffCenter(left, right, bottom, top, 0.01f, 100.0f);
            Matrix4x4 zoom_matrix = Matrix4x4.CreateScale(zoom);

            return orthographic_matrix * zoom_matrix;
        }

        public void update_zoom() {
            zoom += (float)_scroll_delta;
            _scroll_delta = 0.0;
        }
    }
}
