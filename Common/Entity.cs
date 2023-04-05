using OpenTK.Mathematics;

using ArcadiaEngine.Graphics;
using ArcadiaEngine.Graphics.Sprites;
using ArcadiaEngine.Physics;

namespace ArcadiaEngine.Common {
    public interface Entity {
        public Vector2 entity_position { get; set; }
        public float draw_layer { get; set; }

        public bool dead { get; set; }

        public Vector2 entity_scale { get; set; }
        public float entity_rotation { get; set; }
        public Vector4 entity_color { get; set; }

        public SpriteAtlas sprite { get; set; }

        public void draw() {
            GraphicsEngine.draw(sprite.sprite_sheet_name, sprite.get_sprite_info(this));
        }

        public void move();
    }
}
