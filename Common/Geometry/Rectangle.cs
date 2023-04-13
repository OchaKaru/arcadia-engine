using System;

using OpenTK.Mathematics;

namespace ArcadiaEngine.Common.Geometry {
    public class Rectangle : Shape {
        public Vector2 rectangle_position { get; set; }
        public readonly Vector2 rectangle_size;

        public Vector2 rectangle_center { 
            get {
                return rectangle_position + rectangle_size / 2;
            } 
        }

        public Rectangle(Vector2 initial_position, Vector2 size) {
            rectangle_position = initial_position;
            rectangle_size = size;
        }

        public void draw_fill() {

        }
        public void draw_border() {

        }

        public bool intersects(Rectangle other) {
            return rectangle_position.X < other.rectangle_position.X + other.rectangle_size.X &&
                rectangle_position.X + rectangle_size.X > other.rectangle_position.X &&
                rectangle_position.Y < other.rectangle_position.Y + other.rectangle_size.Y &&
                rectangle_position.Y + rectangle_size.Y > other.rectangle_position.Y;
        }
        public bool intersects(Triangle other) {
            return other.intersects(this);
        }
        public bool intersects(Circle other) {
            if(contains(other.circle_center))
                return true;
            else if(closest_edge_point(other.circle_center).distance_to(other.circle_center) < other.circle_radius)
                return true;
            return false;
        }

        public bool contains(Point p) {
            return p.X >= rectangle_position.X && p.X <= rectangle_position.X + rectangle_size.X &&
                p.Y >= rectangle_position.Y && p.Y <= rectangle_position.Y + rectangle_size.Y;
        }

        public Point closest_edge_point(Point p) {
            return new Point(
                Math.Clamp(p.X, rectangle_position.X, rectangle_position.X + rectangle_size.X),
                Math.Clamp(p.Y, rectangle_position.Y, rectangle_position.Y + rectangle_size.Y)
            );
        }
    }
}
