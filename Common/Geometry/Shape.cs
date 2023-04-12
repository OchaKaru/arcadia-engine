using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Common.Geometry {
    internal interface Shape {
        public void draw_fill();
        public void draw_border();

        public bool intersects(Circle other);
        public bool intersects(Rectangle other);
        public bool intersects(Triangle other);

        public bool contains(Point p);
    }
}
