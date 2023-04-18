using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Common.Geometry {
    public abstract class Shape {
        protected float shape_scale;
        protected Vector4 shape_color;

        public abstract void draw_fill();
        public abstract void draw_border();

        public abstract bool intersects(Circle other);
        public abstract bool intersects(Rectangle other);
        public abstract bool intersects(Triangle other);

        public abstract bool contains(Point p);
    }
}
