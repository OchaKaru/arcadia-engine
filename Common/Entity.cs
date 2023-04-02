using OpenTK.Graphics.ES11;
using OpenTK.Mathematics;

namespace ArcadiaEngine.Common {
    public abstract class Entity {
        public Vector2 entity_position { get; set; }
        public float rotation { get; set; }
        public Vector2 entity_velocity { get; set; }

        public bool dead { get; set; }

        public Vector4 entity_color { get; set; }

        public Entity(Vector2 initial_position) {
            entity_position = initial_position;
            rotation = 0;
            entity_velocity = new Vector2(0, 0);

            dead = false;

            entity_color = new Vector4(1, 1, 1, 1);
        }

        public void move() {
            entity_position += entity_velocity;
        }

        public void get_hit_box() {

        }
    }
}
