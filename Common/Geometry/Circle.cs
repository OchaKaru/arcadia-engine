using OpenTK.Mathematics;

using ArcadiaEngine.Graphics;
using ArcadiaEngine.Graphics.Shapes;

namespace ArcadiaEngine.Common.Geometry {
    public class Circle : Shape {
        const int CIRCLE_DEFINITION = 40;

        public Vector2 circle_center;
        public float circle_radius;

        public Circle(Vector2 center, float radius) {
            circle_center = center;
            circle_radius = radius;
        }

        public override void draw_fill() {
            GraphicsEngine.draw(ShapeType.CircleFill, new ShapeInfo(
                create_vertices(),
                circle_radius,
                shape_scale,
                shape_color,
                ShapeType.CircleFill
            ));
        }
        public override void draw_border() {
            GraphicsEngine.draw(ShapeType.CircleLine, new ShapeInfo(
                create_vertices(),
                circle_radius,
                shape_scale,
                shape_color,
                ShapeType.CircleLine
            ));
        }

        private Vector2[] create_vertices() {
            Vector2[] vertices = new Vector2[CIRCLE_DEFINITION];

            for(int i = 0; i < CIRCLE_DEFINITION; i++) {
                
            }
        }

        public override bool intersects(Circle other) {
            if(Point.distance_between(circle_center, other.circle_center) < circle_radius + other.circle_radius)
                return true;
            return false;
        }
        public override bool intersects(Rectangle other) {
            return other.intersects(this);
        }
        public override bool intersects(Triangle other) {
            if(other.contains(circle_center) || contains(other.triangle_center))
                return true;
            else if(contains(other.triangle_vertices[0]) || contains(other.triangle_vertices[1]) || contains(other.triangle_vertices[2]))
                return true;
            else if(other.closest_edge_point(circle_center).distance_to(circle_center) < circle_radius)
                return true;
            return false;
        }

        public override bool contains(Point p) {
            if(p.distance_to(circle_center) < circle_radius)
                return true;
            return false;
        }

    }
}
