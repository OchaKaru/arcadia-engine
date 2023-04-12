using OpenTK.Audio.OpenAL;
using OpenTK.Mathematics;
using System;

namespace ArcadiaEngine.Common.Geometry {
    public class Point {
        public Vector2 point_position;

        public void draw() {

        }

        public float distance_to(Point other) {
            return MathF.Sqrt(MathF.Pow(other.point_position.X - point_position.X, 2) + MathF.Pow(other.point_position.Y - point_position.Y, 2));
        }

        public static float distance_between(Point p1, Point p2) {
            return MathF.Sqrt(MathF.Pow(p2.point_position.X - p1.point_position.X, 2) + MathF.Pow(p2.point_position.Y - p1.point_position.Y, 2));
        }
        public static float distance_between(Point p1, Vector2 p2) {
            return MathF.Sqrt(MathF.Pow(p2.X - p1.point_position.X, 2) + MathF.Pow(p2.Y - p1.point_position.Y, 2));
        }
        public static float distance_between(Vector2 p1, Vector2 p2) {
            return MathF.Sqrt(MathF.Pow(p2.X - p1.X, 2) + MathF.Pow(p2.Y - p1.Y, 2));
        }
    }
}
