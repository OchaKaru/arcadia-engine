using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Common.Geometry {
    public class Triangle {
        public Vector2[] vertices { get; set; }

        public Triangle(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3) {
            vertices = new Vector2[3];
            vertices[0] = vertex1;
            vertices[1] = vertex2;
            vertices[2] = vertex3;
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
