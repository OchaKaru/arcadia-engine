using OpenTK.Mathematics;

namespace ArcadiaEngine.Graphics.Sprites {
    struct SpriteInfo {
        Matrix4 sprite_model;
        Vector4 sprite_color;

        Vector2 sprite_sheet_coords;
        Vector2 sprite_sheet_dimensions;

        public SpriteInfo(Matrix4 model, Vector4 color, Vector2 coords_on_sheet, Vector2 dimensions) {
            sprite_model = model;
            sprite_color = color;

            sprite_sheet_coords = coords_on_sheet;
            sprite_sheet_dimensions = dimensions;
        }
    }
}
