using OpenTK.Mathematics;

using ArcadiaEngine.Common.Geometry;

namespace ArcadiaEngine.Physics {
    public class Hitbox : Rectangle {
        public Hitbox(Vector2 initial_position, Vector2 size) : base(initial_position, size) { }

    }
}
