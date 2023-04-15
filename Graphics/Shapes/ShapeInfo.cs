using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Graphics.Shapes {
    internal struct ShapeInfo {
        Vector2[] positions;
        float size;
        Vector2 scale;
        Vector4 color;

        ShapeType shape;
    }
}
