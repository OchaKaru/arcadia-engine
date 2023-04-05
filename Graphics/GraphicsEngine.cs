﻿using System.Collections.Generic;

using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

using ArcadiaEngine.Common;
using ArcadiaEngine.Common.Exceptions;
using ArcadiaEngine.Graphics.Shaders;
using ArcadiaEngine.Graphics.Sprites;

namespace ArcadiaEngine.Graphics {
    internal class GraphicsEngine {
        private static Vector4 background_color;

        private static Camera? camera;
        private static bool camera_zoom_enabled;
        private static bool camera_follow_enabled;

        private static Entity? entity_to_follow;

        private static Shader? shader;
        private static Dictionary<string, SpriteBatch>? batch_list;

        public static void initialize() {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            background_color = Settings.default_background_color;

            camera = new Camera(WindowManager.window_size / 2.0f, 1.0f);
            camera_zoom_enabled = Settings.enable_camera_zoom ? true : false;
            camera_follow_enabled = Settings.enable_camera_follow ? true : false;

            shader = new DisplayShader(
                "./Shaders/sprite-rendering/sprite.vert",
                "./Shaders/sprite-rendering/sprite.frag"
            );

            batch_list = SpriteLoader.load_sprites();

            if(camera_zoom_enabled)
                camera.enable_zoom_on_scroll();
        }

        public static void set_follow_entity(in Entity entity) {
            entity_to_follow = entity;
        }

        public static void update_camera() {
            if(camera_zoom_enabled)
                camera.update_zoom();
                
            if(camera_follow_enabled && entity_to_follow is not null)
                camera.focus_position = entity_to_follow.entity_position;
            else
                throw new FollowEntityNotSetError("ARCADIA ENGINE ERROR: The entity to follow was not set before updating the camera.");

        }

        public static void clear_color() {
            GL.ClearColor(background_color.X, background_color.Y, background_color.Z, background_color.W);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public static void draw(string sprite_sheet, params SpriteInfo[] sprites) {
            batch_list[sprite_sheet].add_sprite(sprites);
        }

        public static void render() {
            shader.use();
            
            shader.set_uniform("sprite_sheet", 0);
            shader.set_matrix("projection", camera.get_projection_matrix());

            foreach(SpriteBatch batch in batch_list.Values)
                if(batch.sprites.Count > 0)
                    batch.draw();
        }
    }
}
