using OpenTK.Mathematics;

namespace ArcadiaEngine.Common.Geometry {
    public class Circle : Shape{
        public Vector2 circle_center;
        public float circle_radius;

        public Circle(Vector2 center, float radius) {
            circle_center = center;
            circle_radius = radius;
        }

        public void draw_fill() {

        }
        public void draw_border() {

        }

        public bool intersects(Circle other) {

        }
        public bool intersects(Rectangle other) {
            return other.intersects(this);
        }
        public bool intersects(Triangle other) {

        }

        public bool contains(Point p) {
            
        }

    }
}
