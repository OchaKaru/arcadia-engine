using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Graphics.Shapes {
    internal struct ShapeInfo {
        public Vector2[] positions;
        public float factor;
        public float scale;
        public Vector4 color;

        public ShapeType shape;

        public ShapeInfo(Vector2[] position_array, float modifier, float shape_scale, Vector4 shape_color, ShapeType type) {
            positions = position_array;
            factor = modifier;
            scale = shape_scale;
            color = shape_color;
            shape = type;
        }
    }
}
