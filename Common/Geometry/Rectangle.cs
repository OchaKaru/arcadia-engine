using ArcadiaEngine.Physics;
using OpenTK.Mathematics;

namespace ArcadiaEngine.Common.Geometry {
    public class Rectangle {
        public Vector2 rectangle_position { get; set; }
        public readonly Vector2 rectangle_size;

        public Rectangle(Vector2 initial_position, Vector2 size) {
            rectangle_position = initial_position;
            rectangle_size = size;
        }

        public void draw() {

        }

        public bool intersects(Rectangle other) {
            return rectangle_position.X < other.rectangle_position.X + other.rectangle_size.X &&
                rectangle_position.X + rectangle_size.X > other.rectangle_position.X &&
                rectangle_position.Y < other.rectangle_position.Y + other.rectangle_size.Y &&
                rectangle_position.Y + rectangle_size.Y > other.rectangle_position.Y;
        }
        public bool intersects(Triangle other) {
            
        }
        public bool intersects(Circle other) {

        }

        public bool contains(Point p) {
            return p.point_position.X >= rectangle_position.X &&
                p.point_position.X <= rectangle_position.X + rectangle_size.X &&
                p.point_position.Y >= rectangle_position.Y &&
                p.point_position.Y <= rectangle_position.Y + rectangle_size.Y;
        }
    }
}
