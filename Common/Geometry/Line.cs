using OpenTK.Mathematics;

namespace ArcadiaEngine.Common.Geometry {
    internal class Line {
        public Vector2 point_a;
        public Vector2 point_b;

        public float line_length { get {
                return Point.distance_between(point_a, point_b);
            }
        }

        public Line(float a_x, float a_y, float b_x, float b_y) {
            point_a = new Vector2(a_x, a_y);
            point_b = new Vector2(b_x, b_y);
        }
        public Line(Vector2 a, Vector2 b) {
            point_a = a;
            point_b = b;
        }

        public void draw() {

        }

        public bool intersects(Line other) {
            float d = (other.point_b.Y - other.point_a.Y) * (point_b.X - point_a.X) - (other.point_b.X - other.point_a.X) * (point_b.Y - point_a.Y);
            float u = (other.point_b.X - other.point_a.X) * (point_a.Y - other.point_a.Y) - (other.point_b.Y - other.point_a.Y) * (point_a.X - other.point_a.X);
            float v = (point_b.X - point_a.X) * (point_a.Y - other.point_a.Y) - (point_b.Y - point_a.Y) * (point_a.X - other.point_a.X);
            if (d < 0) {
                d *= -1;
                u *= -1; 
                v *= -1;
            }

            return (0 <= u && u <= d) && (0 <= v && v <= d);
        }

        public static bool lines_intersect(Line l1, Line l2) {
            return l1.intersects(l2);
        }

        public static bool lines_intersect(Vector2 v1, Vector2 v2, Vector2 v3, Vector2 v4) {
            float d = (v4.Y - v3.Y) * (v2.X - v1.X) - (v4.X - v3.X) * (v2.Y - v1.Y);
            float u = (v4.X - v3.X) * (v1.Y - v3.Y) - (v4.Y - v3.Y) * (v1.X - v3.X);
            float v = (v2.X - v1.X) * (v1.Y - v3.Y) - (v2.Y - v1.Y) * (v1.X - v3.X);
            if(d < 0) {
                d *= -1;
                u *= -1;
                v *= -1;
            }

            return (0 <= u && u <= d) && (0 <= v && v <= d);
        }
    }
}
