using OpenTK.Mathematics;

using ArcadiaEngine.Graphics;
using ArcadiaEngine.Graphics.Sprites;
using ArcadiaEngine.Physics;
using System;

namespace ArcadiaEngine.Common {
    public abstract class Entity {
        public Vector2 entity_position { get; set; }
        public int draw_layer { get; set; }

        public bool dead { get; set; }

        public Vector2 entity_scale { get; set; }
        public float entity_rotation { get; set; }
        public Vector4 entity_color { get; set; }

        public SpriteAtlas sprite { get; set; }

        public void set_camera_to_follow() {
            GraphicsEngine.set_follow_entity(this);
        }

        public void draw() {
            GraphicsEngine.draw(sprite.sprite_sheet_name, sprite.get_sprite_info(this));
        }

        public abstract void move();
    }
}
