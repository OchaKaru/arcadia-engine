using OpenTK.Mathematics;

using ArcadiaEngine.Graphics;
using ArcadiaEngine.Physics;

namespace ArcadiaEngine.Common {
    internal interface Entity {
        public Vector2 entity_position { get; set; }

        public bool dead { get; set; }

        public Vector2 entity_scale { get; set; }
        public float rotation { get; set; }
        public Vector4 entity_color { get; set; }

        public void camera_follow() {
            GraphicsEngine.set_follow_entity(this);
        }

        public void draw();

        public Hitbox get_hit_box();
        public void move();
    }
}
