using OpenTK.Mathematics;

using ArcadiaEngine.Graphics;
using ArcadiaEngine.Graphics.Sprites;
using ArcadiaEngine.Physics;
using ArcadiaEngine.Physics.Bodies;
using System;

namespace ArcadiaEngine.Common {
    public abstract class Entity {
        public PhysicsBody body { get; set; }

        public bool dead { get; set; }

        public Vector2 entity_scale { get; set; }
        public float entity_rotation { get; set; }
        public Vector4 entity_color { get; set; }
        public int draw_layer { get; set; }

        public SpriteAtlas sprite { get; set; }

        public void set_camera_to_follow() {
            GraphicsEngine.set_follow_entity(this);
        }

        public void move() {
            PhysicsEngine.update(body);
        }
        public void draw() {
            GraphicsEngine.draw(sprite.sprite_sheet_name, sprite.get_sprite_info(this));
        }

        public void set_collision_event(Action<CollisionEvent> collision_action) {
            body.on_collision = collision_action;
        }
    }
}
