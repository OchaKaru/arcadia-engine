using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ArcadiaEngine.Graphics {
    public class Camera {
        public Vector2 focus_position { get; set; }
        public float zoom { get; set; }

        private double _scroll_delta = 0;

        private GLFWCallbacks.ScrollCallback zoomOnScroll;

        public Camera(Vector2 initial_focus_position, float initial_zoom) {
            focus_position = initial_focus_position;
            zoom = initial_zoom;

            unsafe {
                zoomOnScroll = (Window, x, y) => {
                    _scroll_delta = y;
                };
            }
        }

        public Matrix4 get_projection_matrix() {
            float left = focus_position.X - WindowManager.window_size.X / 2f;
            float right = focus_position.X + WindowManager.window_size.X / 2f;
            float bottom = focus_position.Y + WindowManager.window_size.Y / 2f;
            float top = focus_position.Y - WindowManager.window_size.Y / 2f;

            Matrix4 orthographic_matrix = Matrix4.CreateOrthographicOffCenter(left, right, bottom, top, -100, 100);
            Matrix4 zoom_matrix = Matrix4.CreateScale(zoom);

            return orthographic_matrix * zoom_matrix;
        }

        public void enable_zoom_on_scroll() {
            WindowManager.set_scroll_callback(zoomOnScroll);
        }

        public void update_zoom() {
            zoom += (float)_scroll_delta;
            _scroll_delta = 0.0;

            if(zoom < 1)
                zoom = 1;
        }
    }
}
