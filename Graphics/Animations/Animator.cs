using OpenTK.Mathematics;

using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics.Sprites;
using ArcadiaEngine.Graphics.Animations.Nodes;
using ArcadiaEngine.Physics;

namespace ArcadiaEngine.Graphics.Animations
{
    public class Animator : SpriteAtlas {
        private float internal_clock;
        private int frames_per_second;
        private Vector2 current_frame;

        private AnimatorState current_state;
        private AnimatorState next_state;

        private AnimatorNode animation_tree;

        public Animator(string sheet_name, Vector2 sprite_pixel_size, Vector2 sheet_dimensions) : base(sheet_name, sprite_pixel_size, sheet_dimensions) { }

        /*
        public Animator(string animator_code_path) {
            ArcaniCompiler.compile(animator_code_path);
            sprite_sheet_name = ArcaniCompiler.get_sheet_name();
            sprite_sheet_dimensions = ArcaniCompiler.get_sheet_dimenstions();
            sprite_size = ArcaniCompiler.get_sprite_size();
            current_state = ArcaniCompiler.get_initial_state();
            root = ArcaniCompiler.get_resolution_tree();

            initialize(sprite_sheet_name, sprite_size, sprite_sheet_dimensions);            
        }
        */

        private Vector2 update_frame() {
            foreach(AnimationController controller in current_state.get_controllers())
                current_state.remove_controller(controller);

            return animation_tree.resolve();
        }


        internal override SpriteInfo get_sprite_info(Entity entity) {
            internal_clock += Timer.delta_time;
            float time_per_frame = 1 / frames_per_second;
            while(internal_clock > time_per_frame) {
                internal_clock -= time_per_frame;
                current_frame = update_frame();
            }

            return new SpriteInfo(
                Matrix4.CreateScale(entity.entity_scale.X, entity.entity_scale.Y, 1) *
                Matrix4.CreateScale(sprite_size.X, sprite_size.Y, 1) *
                Matrix4.CreateRotationZ(entity.entity_rotation) *
                Matrix4.CreateTranslation(entity.entity_position.X, entity.entity_position.Y, 0),
                entity.entity_color,
                entity.draw_layer,
                current_frame,
                sprite_sheet_dimensions
            );
        }
    }
}
