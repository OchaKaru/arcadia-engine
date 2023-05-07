using OpenTK.Mathematics;

using ArcadiaEngine.Graphics;
using ArcadiaEngine.Graphics.Shapes;
using System;

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
            GraphicsEngine.draw(new ShapeInfo(
                create_triangels(),
                shape_scale,
                shape_color,
                ShapeType.CircleFill
            ));
        }
        public override void draw_border() {
            GraphicsEngine.draw(new ShapeInfo(
                create_border(),
                shape_scale,
                shape_color,
                ShapeType.CircleLine
            ));
        }

        private Vector2[] create_triangels() {
            Vector2[] vertices = new Vector2[3 * CIRCLE_DEFINITION];

            for(int i = 0; i < CIRCLE_DEFINITION; i++) {
                vertices[i * 3 + 0] = circle_center;
                vertices[i * 3 + 1] = new Vector2(
                    circle_center.X + circle_radius * MathF.Cos(2 * i * MathF.PI / CIRCLE_DEFINITION),
                    circle_center.Y + circle_radius * MathF.Sin(2 * i * MathF.PI / CIRCLE_DEFINITION)
                );
                vertices[i * 3 + 2] = new Vector2(
                    circle_center.X + circle_radius * MathF.Cos(2 * (i + 1) * MathF.PI / CIRCLE_DEFINITION),
                    circle_center.Y + circle_radius * MathF.Sin(2 * (i + 1) * MathF.PI / CIRCLE_DEFINITION)
                );
            }

            return vertices;
        }
        private Vector2[] create_border() {
            Vector2[] vertices = new Vector2[CIRCLE_DEFINITION + 1];

            for(int i = 0; i < CIRCLE_DEFINITION + 1; i++)
                vertices[i] = new Vector2(
                    circle_center.X + circle_radius * MathF.Cos(2 * i * MathF.PI / CIRCLE_DEFINITION),
                    circle_center.Y + circle_radius * MathF.Sin(2 * i * MathF.PI / CIRCLE_DEFINITION)
                );

            return vertices;
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
