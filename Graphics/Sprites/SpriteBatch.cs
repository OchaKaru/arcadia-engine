using System.Numerics;

using ArcadiaEngine.Exceptions;
using ArcadiaEngine.Graphics.Shaders;

namespace ArcadiaEngine.Graphics.Sprites {
    class SpriteBatch {
        private const int MAX_QUADS = 100;

        public DisplayShader shader { get; set; }

        public Texture sprite_sheet { get; set; }
        public Vector2 sheet_dimensions { get; set; }

        private Vector2 sprite_pixel_size;
        private Vector2 sprite_texture_size;

        public SpriteBatch(string sprite_path, Vector2 dimensions, string vertext_shader_path, string fragment_shader_path) {
            shader = new DisplayShader(vertext_shader_path, fragment_shader_path);

            sprite_sheet = new Texture(sprite_path);
            sheet_dimensions = dimensions;

            sprite_pixel_size = new Vector2(
                sprite_sheet.texture_size.X / sheet_dimensions.X,
                sprite_sheet.texture_size.Y / sheet_dimensions.Y
            );
            sprite_texture_size = new Vector2(1 / sheet_dimensions.X, 1 / sheet_dimensions.Y);
        }

        public void render(SpriteInfo[] sprites) {
            shader.use();

            if (sprites.Length > MAX_QUADS)
                throw new InvalidLengthError("ARCADIA ENGINE ERROR: The sprites array length exceeded the maximum quads avaiable.");
        }
    }
}
