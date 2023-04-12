using OpenTK.Mathematics;

namespace ArcadiaEngine.Common.Geometry {
    public class Circle {
        Vector2 circle_center;
        Vector2 circle_radius;

        public Circle(Vector2 center, Vector2 radius) {
            circle_center = center;
            circle_radius = radius;
        }

        public bool intersects(Rectangle other) {
            
        }
        public bool intersects(Triangle other) {

        }
        public bool intersects(Circle other) {

        }

        public bool contains(Point p) {
            
        }

    }
}
