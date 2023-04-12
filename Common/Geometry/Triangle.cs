using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Common.Geometry {
    public class Triangle : Shape {
        public Vector2[] triangle_vertices { get; set; }

        public Vector2 triangle_center { 
            get {
                return
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

        }
        public bool intersects(Triangle other) {

        }
        public bool intersects(Circle other) {

        }

        public bool contains(Point p) {

        }
    }
}
