using System;
using System.Collections.Generic;

using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

using ArcadiaEngine.Common;
using ArcadiaEngine.Physics;
using ArcadiaEngine.Graphics.Shaders;
using ArcadiaEngine.Graphics.Sprites;

namespace ArcadiaEngine.Graphics {
    public class Renderer {
        public static int current_frame = 0;
        public static float time_last_frame = 0;
        public static int flip = 1;
        public static float walk = 0;

        public static Vector4 background_color { get; set; }

        public static Camera camera { get; set; }
        private static Shader shader;
        private static Dictionary<string, SpriteBatch> batch_list;

        public static void initialize() {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            Console.WriteLine(GL.GetString(StringName.Version), GL.GetString(StringName.Renderer), GL.GetString(StringName.Vendor));

            camera = new Camera(WindowManager.window_size / 2.0f, 1.0f);
            shader = new DisplayShader(
                @"C:\Users\Plutarco\Documents\Documents\Projects\game-engine\arcadia-engine\Graphics\Shaders\sprite-rendering\sprite.vert",
                @"C:\Users\Plutarco\Documents\Documents\Projects\game-engine\arcadia-engine\Graphics\Shaders\sprite-rendering\sprite.frag"
            );

            batch_list = SpriteLoader.load_sprites();
        }

        public static void clear_color() {
            GL.ClearColor(background_color.X, background_color.Y, background_color.Z, background_color.W);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public static void draw() {
            if(Timer.elapsed_time - time_last_frame > .125) {
                current_frame++;
                time_last_frame = Timer.elapsed_time;
            }

            if(walk > 864 || walk < -64)
                flip *= -1;
            walk = walk + .02f * flip;

            shader.use();
            shader.set_uniform("sprite_sheet", 0);
            shader.set_matrix("projection", camera.get_projection_matrix());



            Matrix4 model1 =
                Matrix4.CreateScale(1, 1, 1) *
                Matrix4.CreateScale(flip * 64, 64, 1) *
                Matrix4.CreateRotationZ(0) *
                Matrix4.CreateTranslation(0 + walk, 300, 0);

            Matrix4 model2 =
                Matrix4.CreateScale(1, 1, 1) *
                Matrix4.CreateScale(64, 64, 1) *
                Matrix4.CreateRotationZ(0) *
                Matrix4.CreateTranslation(400, 300, 0);

            batch_list["cat-man"].add_sprite(
                new SpriteInfo(
                    model1,
                    new Vector4(1, 0, 1, 1),
                    new Vector2((current_frame + 1) % 6, 0),
                    new Vector2(6, 2)
                ), 
                new SpriteInfo(
                    model2,
                    new Vector4(1, 1, 1, 1),
                    new Vector2((current_frame + 1) % 4, 1),
                    new Vector2(6, 2)
                )
            );

            batch_list["cat-man"].draw();
        }
    }
}
