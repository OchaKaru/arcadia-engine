using OpenTK.Mathematics;

namespace ArcadiaEngine.Common.Geometry {
    public class Square : Rectangle {
        public readonly float side_length;

        public Square(Vector2 initial_position, float side) : base(initial_position, new Vector2(side, side)) {
            side_length = side;
        }
    }
}
