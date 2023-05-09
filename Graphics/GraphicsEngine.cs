using System.Collections.Generic;

using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

using ArcadiaEngine.Common;
using ArcadiaEngine.Common.Exceptions;
using ArcadiaEngine.Graphics.Shaders;
using ArcadiaEngine.Graphics.Sprites.Rendering;

namespace ArcadiaEngine.Graphics
{
    internal class GraphicsEngine {
        private static Vector4 background_color;

        private static Camera? camera;
        private static bool camera_zoom_enabled;
        private static bool camera_follow_enabled;

        private static Entity? entity_to_follow;

        private static Shader? sprite_shader;
        private static Dictionary<string, SpriteRenderer>? sprite_renderer_list;

        public static void initialize() {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            background_color = Settings.default_background_color;

            camera = new Camera(WindowManager.window_size / 2.0f, 1.0f);
            camera_zoom_enabled = Settings.enable_camera_zoom ? true : false;
            camera_follow_enabled = Settings.enable_camera_follow ? true : false;

            sprite_shader = new DisplayShader(
                @"C:\Users\Plutarco\Documents\Documents\Projects\game-engine\arcadia-engine\Graphics\Shaders\sprite-rendering\sprite.vert",
                @"C:\Users\Plutarco\Documents\Documents\Projects\game-engine\arcadia-engine\Graphics\Shaders\sprite-rendering\sprite.frag"
            );
            sprite_renderer_list = SpriteLoader.load_sprites();

            if(camera_zoom_enabled)
                camera.enable_zoom_on_scroll();
        }

        public static void set_follow_entity(in Entity entity) {
            entity_to_follow = entity;
        }

        public static void update_camera() {
            if(camera_zoom_enabled)
                camera.update_zoom();
                
            if(camera_follow_enabled)
                if(camera_follow_enabled)
                    camera.focus_position = entity_to_follow.entity_position;
                else
                    throw new FollowEntityNotSetError("ARCADIA ENGINE ERROR: The entity to follow was not set before updating the camera.");

        }

        public static void clear_color() {
            GL.ClearColor(background_color.X, background_color.Y, background_color.Z, background_color.W);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public static void draw(string sprite_sheet, params SpriteInfo[] sprites) {
            sprite_renderer_list[sprite_sheet].add_sprite(sprites);
        }

        public static void render() {
            sprite_shader.use();

            sprite_shader.set_uniform("sprite_sheet", 0);
            sprite_shader.set_matrix("projection", camera.get_projection_matrix());

            foreach(SpriteRenderer sprite_renderer in sprite_renderer_list.Values)
                if(sprite_renderer.sprites.Count > 0)
                    sprite_renderer.draw();
        }
    }
}
