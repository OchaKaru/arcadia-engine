using OpenTK.Mathematics;

using ArcadiaEngine.Common.Geometry;
using ArcadiaEngine.Common.Exceptions;

namespace ArcadiaEngine.Physics {
    public class Hitbox {
        internal Shape hitbox_shape;

        private Hitbox(Shape shape) {
            hitbox_shape = shape;
        }


        public static implicit operator Hitbox(Circle circle) {
            return new Hitbox(circle);
        }
        public static implicit operator Hitbox(Triangle triangle) {
            return new Hitbox(triangle);
        }
        public static implicit operator Hitbox(Rectangle rectangle) {
            return new Hitbox(rectangle);
        }
        public static implicit operator Hitbox(Square square) {
            return new Hitbox(square);
        }

        public void draw() {
            hitbox_shape.draw_border();
        }

        public bool intersects(Hitbox other) {
            if(other.hitbox_shape is Rectangle)
                return hitbox_shape.intersects((Rectangle)other.hitbox_shape);
            else if(other.hitbox_shape is Circle)
                return hitbox_shape.intersects((Circle)other.hitbox_shape);
            else if(other.hitbox_shape is Triangle)
                return hitbox_shape.intersects((Triangle)other.hitbox_shape);
            else
                throw new ShapeNotValidError("ARCADIA ENGINE ERROR: The shape of the hitbox doesn't match any of the valid shapes available.");
        }
    }
}
