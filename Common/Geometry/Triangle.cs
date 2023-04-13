using System;

using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using ArcadiaEngine.Graphics.Shapes;

namespace ArcadiaEngine.Common.Geometry
{
    public class Triangle : Shape {
        public Vector2[] triangle_vertices { get; set; }

        public Vector2 triangle_center { 
            get {
                return (triangle_vertices[0] + triangle_vertices[1] + triangle_vertices[2]) / 3;
            }
        }

        public Triangle(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3) {
            triangle_vertices = new Vector2[3];
            triangle_vertices[0] = vertex1;
            triangle_vertices[1] = vertex2;
            triangle_vertices[2] = vertex3;
        }

        public void draw_fill() {

        }
        public void draw_border() {
            
        }

        public bool intersects(Rectangle other) {
            if(other.contains(triangle_center))
                return true;
            for(int i = 0; i < 3; i++) {
                float slope = (triangle_vertices[i + 1 % 3].Y - triangle_vertices[i].Y) / (triangle_vertices[i + 1 % 3].X - triangle_vertices[i].X);

                float intersection_one = slope * (other.rectangle_position.X - triangle_vertices[i].X) + triangle_vertices[i].Y;
                float intersection_two = slope * (other.rectangle_position.X + other.rectangle_size.X - triangle_vertices[i].X) + triangle_vertices[i].Y;

                float overlap_top = other.rectangle_position.Y;
                float overlap_bottom = other.rectangle_position.Y + other.rectangle_size.Y;

                if(intersection_one > overlap_top && intersection_one < overlap_bottom)
                    overlap_top = (intersection_one < intersection_two) ? intersection_one : intersection_two;
                if(intersection_two > overlap_top && intersection_two < overlap_bottom)
                    overlap_bottom = (intersection_one < intersection_two) ? intersection_two : intersection_one;

                bool vertex_one_in_overlap = triangle_vertices[i].Y > overlap_top && triangle_vertices[i].Y < overlap_bottom;
                bool vertex_two_in_overlap = triangle_vertices[i + 1 % 3].Y > overlap_top && triangle_vertices[i + 1 % 3].Y < overlap_bottom;

                if(vertex_one_in_overlap || vertex_two_in_overlap)
                    return true;
            }

            return false;
        }
        public bool intersects(Triangle other) {
            if(contains(other.triangle_center) || other.contains(triangle_center))
                return true;
            else if(other.contains(triangle_vertices[0]) || other.contains(triangle_vertices[1]) || other.contains(triangle_vertices[2]))
                return true;
            else if(contains(other.triangle_vertices[0]) || contains(other.triangle_vertices[1]) || contains(other.triangle_vertices[2]))
                return true;
            return false;
        }
        public bool intersects(Circle other) {
            return other.intersects(this);
        }

        public bool contains(Point p) {
            var sign = (Vector2 p1, Vector2 p2, Vector2 p3) => {
                return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
            };

            float d1 = sign(p, triangle_vertices[0], triangle_vertices[1]);
            float d2 = sign(p, triangle_vertices[1], triangle_vertices[2]);
            float d3 = sign(p, triangle_vertices[2], triangle_vertices[0]);

            bool has_negative = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool has_positive = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_negative && has_positive);
        }

        public Point closest_edge_point(Point p) {
            float distance = float.MaxValue;
            Point closest = p;

            for(int i = 0; i < 3; i++) {
                float slope = (triangle_vertices[i + 1 % 3].Y - triangle_vertices[i].Y) / (triangle_vertices[i + 1 % 3].X - triangle_vertices[i].X);

                Point check_point = new Point(
                    (triangle_vertices[i].X * MathF.Pow(slope, 2) + (p.Y - triangle_vertices[i].Y) * slope + p.X) / (MathF.Pow(slope, 2) + 1),
                    (p.Y * MathF.Pow(slope, 2) + (p.X - triangle_vertices[i].X) * slope + triangle_vertices[i].Y) / (MathF.Pow(slope, 2) + 1)
                );
                if(!contains(check_point))
                    check_point = triangle_vertices[i];

                float check_distance = p.distance_to(check_point);

                if(check_distance < distance) {
                    distance = check_distance;
                    closest = check_point;
                }
            }

            return closest;
        }
    }
}
