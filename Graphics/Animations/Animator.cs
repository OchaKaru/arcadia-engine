using OpenTK.Mathematics;


using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics.Sprites;

namespace ArcadiaEngine.Graphics.Animations
{
    public class Animator {
        public string sprite_sheet { get; set; }
        private Vector2 sprite_sheet_dimensions;
        private Vector2 sprite_size;

        private AnimationTree tree;

        public Animator(string sheet_name, string sprite_sheet_path, Vector2 sheet_dimensions) {
            sprite_sheet = sheet_name;

            (_, Vector2 sprite_sheet_size) = Texture.image_data(sprite_sheet_path);
            sprite_sheet_dimensions = sheet_dimensions;
            sprite_size = sprite_sheet_size / sprite_sheet_dimensions;

            tree = new AnimationTree();
        }

        public Animator(string animator_code_path) {
            tree = ArcaniCompiler.compile(animator_code_path);
        }

        public void draw(EntityState entity) {
            Matrix4 sprite_model =
                Matrix4.CreateScale(entity.scale.X, entity.scale.Y, 1) *
                Matrix4.CreateScale(sprite_size.X, sprite_size.Y, 1) *
                Matrix4.CreateRotationZ(entity.rotation) *
                Matrix4.CreateTranslation(entity.positon.X, entity.positon.Y, 0);

            SpriteInfo sprite = new SpriteInfo(
                sprite_model,
                entity.color,
                tree.next_frame(entity),
                sprite_sheet_dimensions
            );

            GraphicsEngine.draw(sprite_sheet, sprite);
        }
    }
}
