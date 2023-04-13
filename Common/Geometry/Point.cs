using System;

using OpenTK.Mathematics;

namespace ArcadiaEngine.Common.Geometry {
    public class Point {
        public Vector2 point_position { private get; set; }
        public float X { get { return point_position.X; } }
        public float Y { get { return point_position.Y; } }

        public Point(float x, float y) {
            point_position = new Vector2(x, y);
        }
        public Point(Vector2 position) {
            point_position = position;
        }

        public void draw() {

        }

        public float distance_to(Point other) {
            return MathF.Sqrt(MathF.Pow(other.point_position.X - point_position.X, 2) + MathF.Pow(other.point_position.Y - point_position.Y, 2));
        }

        public static float distance_between(Point p1, Point p2) {
            return MathF.Sqrt(MathF.Pow(p2.point_position.X - p1.point_position.X, 2) + MathF.Pow(p2.point_position.Y - p1.point_position.Y, 2));
        }


        public static implicit operator Vector2(Point p) {
            return p.point_position;
        }
        public static implicit operator Point(Vector2 point) {
            return new Point(point);
        }
    }
}
