using OpenTK.Mathematics;

using ArcadiaEngine.Common;

namespace ArcadiaEngine.Graphics.Sprites {
    public abstract class SpriteAtlas {
        internal string sprite_sheet_name { get; set; }
        protected Vector2 sprite_size;
        protected Vector2 sprite_sheet_dimensions;

        internal SpriteAtlas() { }
        internal SpriteAtlas(string sprite_name, Vector2 sprite_pixel_size, Vector2 sheet_dimensions) {
            initialize(sprite_name, sprite_pixel_size, sheet_dimensions);
        }

        protected void initialize(string sprite_name, Vector2 sprite_pixel_size, Vector2 sheet_dimensions) {
            sprite_sheet_name = sprite_name;

            sprite_size = sprite_pixel_size;
            sprite_sheet_dimensions = sheet_dimensions;
        }

        internal abstract SpriteInfo get_sprite_info(Entity entity);
    }
}
