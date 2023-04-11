using OpenTK.Mathematics;

namespace ArcadiaEngine.Graphics.Sprites {
    internal struct SpriteInfo {
        public Matrix4 sprite_model;
        public Vector4 sprite_color;

        //public int z_index;

        public Vector2 sprite_sheet_coordinates;
        public Vector2 sprite_sheet_dimensions;

        public SpriteInfo(Matrix4 model, Vector4 color, /* int draw_layer,*/ Vector2 coords_on_sheet, Vector2 dimensions) {
            sprite_model = model;
            sprite_color = color;

            //z_index = draw_layer;

            sprite_sheet_coordinates = coords_on_sheet;
            sprite_sheet_dimensions = dimensions;
        }
    }
}
