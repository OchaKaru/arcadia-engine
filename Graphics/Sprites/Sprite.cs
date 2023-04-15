using OpenTK.Mathematics;

using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics.Sprites.Rendering;

namespace ArcadiaEngine.Graphics.Sprites
{
    public class Sprite : SpriteAtlas {
        public Vector2 sprite_coordinate { get; set; }

        public Sprite(string sheet_name, Vector2 sprite_pixel_size, Vector2 sheet_dimensions, Vector2 sprite_coord) : base(sheet_name, sprite_pixel_size, sheet_dimensions) {
            sprite_coordinate = sprite_coord;
        }

        internal override SpriteInfo get_sprite_info(Entity entity) {
            return new SpriteInfo(
                Matrix4.CreateScale(entity.entity_scale.X, entity.entity_scale.Y, 1) *
                Matrix4.CreateScale(sprite_size.X, sprite_size.Y, 1) *
                Matrix4.CreateRotationZ(entity.entity_rotation) *
                Matrix4.CreateTranslation(entity.entity_position.X, entity.entity_position.Y, 0),
                entity.entity_color,
                //entity.draw_layer,
                sprite_coordinate,
                sprite_sheet_dimensions
            );
        }
    }
}
