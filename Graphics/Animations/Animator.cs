using System;
using System.Collections.Generic;

using OpenTK.Mathematics;

using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics.Sprites;
using ArcadiaEngine.Graphics.Animations.Nodes;
using ArcadiaEngine.Physics;

namespace ArcadiaEngine.Graphics.Animations {
    using ControllerDictionary = Dictionary<string, int>;

    public class Animator : SpriteAtlas {
        private float internal_clock;
        private int frames_per_second;
        private Vector2 current_frame;

        private AnimatorState current_state;
        private AnimatorState next_state;

        private Action update_state;

        private AnimatorNode animation_tree;

        public Animator(string sheet_name, Vector2 sprite_pixel_size, Vector2 sheet_dimensions, ControllerDictionary controllers, int fps = 8) : base(sheet_name, sprite_pixel_size, sheet_dimensions) {
            internal_clock = 0;
            frames_per_second = fps;

            current_state = new AnimatorState(controllers);
            next_state = new AnimatorState(controllers);

            update_state = () => {
                return;
            };

            animation_tree = new DecisionNode("isMoving", null,
                new TerminalNode("idle", null,
                    new Frame(new Vector2(0, 1), new ControllerDictionary {{"idle", 1}}),
                    new Frame(new Vector2(1, 1), new ControllerDictionary {{"idle", 2}}),
                    new Frame(new Vector2(2, 1), new ControllerDictionary {{"idle", 3}}),
                    new Frame(new Vector2(3, 1), new ControllerDictionary {{"idle", 0}})
                ),
                new TerminalNode("walking", null,
                    new Frame(new Vector2(0, 0), new ControllerDictionary {{"walking", 1}}),
                    new Frame(new Vector2(1, 0), new ControllerDictionary {{"walking", 2}}),
                    new Frame(new Vector2(2, 0), new ControllerDictionary {{"walking", 3}}),
                    new Frame(new Vector2(3, 0), new ControllerDictionary {{"walking", 4}}),
                    new Frame(new Vector2(4, 0), new ControllerDictionary {{"walking", 5}}),
                    new Frame(new Vector2(5, 0), new ControllerDictionary {{"walking", 0}})
                )
            );
        }

        public void set_controller(string name, int value) {
            next_state.set_controller_value(name, value);
        }

        public void set_controller_state_updater(Action state_updater) {
            update_state = state_updater;
        }

        private Vector2 update_frame() {
            update_state();

            current_state.add_controller(next_state.get_controllers());
            //next_state.clear();
            return animation_tree.resolve(current_state, next_state).get_frame(current_state, next_state);
        }

        internal override SpriteInfo get_sprite_info(Entity entity) {
            internal_clock += Timer.delta_time;
            float time_per_frame = 1.0f / frames_per_second;
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
                //entity.draw_layer,
                current_frame,
                sprite_sheet_dimensions
            );
        }
    }
}
