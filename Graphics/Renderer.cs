using System;
using System.Collections.Generic;

using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

using ArcadiaEngine.Common;
using ArcadiaEngine.Physics;
using ArcadiaEngine.Graphics.Shaders;
using ArcadiaEngine.Graphics.Sprites;

namespace ArcadiaEngine.Graphics {
    class Renderer {
        public static int current_frame = 0;
        public static float time_last_frame = 0;

        public static Vector4 background_color { get; set; }

        public static Camera camera { get; set; }
        public static Shader shader { get; set; }
        public static SpriteBatch batch_list {  get; set; }

        public static void initialize() {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            Console.WriteLine(GL.GetString(StringName.Version), GL.GetString(StringName.Renderer), GL.GetString(StringName.Vendor));

            camera = new Camera(WindowManager.window_size / 2.0f, 1.0f);
            shader = new DisplayShader(
                @"C:\Users\Plutarco\Documents\Documents\Projects\arcadia-engine\arcadia-engine\Graphics\Shaders\sprite-rendering\sprite.vert",
                @"C:\Users\Plutarco\Documents\Documents\Projects\arcadia-engine\arcadia-engine\Graphics\Shaders\sprite-rendering\sprite.frag"
            );

            batch_list = new SpriteBatch(@"C:\Users\Plutarco\Documents\Documents\Projects\arcadia-engine-legacy\test-assets\cat-man.png");
        }

        public static void clear_color() {
            GL.ClearColor(background_color.X, background_color.Y, background_color.Z, background_color.W);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public static void draw() {
            if(Timer.elapsed_time - time_last_frame > .6) {
                current_frame = (current_frame + 1) % 3;
                time_last_frame = Timer.elapsed_time;
            }

            shader.use();
            shader.set_uniform("sprite_sheet", 0);
            shader.set_matrix("projection", camera.get_projection_matrix());

            Matrix4 model1 =
                Matrix4.CreateScale(1, 1, 1) *
                Matrix4.CreateScale(200, 200, 1) *
                Matrix4.CreateRotationZ(0) *
                Matrix4.CreateTranslation(0, 0, 0);

            Matrix4 model2 =
                Matrix4.CreateScale(1, 1, 1) *
                Matrix4.CreateScale(200, 200, 1) *
                Matrix4.CreateRotationZ(0) *
                Matrix4.CreateTranslation(200, 0, 0);

            batch_list.add_sprite(
                new SpriteInfo(
                    model1,
                    new Vector4(1, 0, 1, 1),
                    new Vector2(current_frame, 0),
                    new Vector2(3, 1)
                ), 
                new SpriteInfo(
                    model2,
                    new Vector4(1, 1, 1, 1),
                    new Vector2((current_frame + 1) % 3, 0),
                    new Vector2(3, 1)
                ),
                new SpriteInfo(
                    model2,
                    new Vector4(1, 1, 1, 1),
                    new Vector2((current_frame + 2) % 3, 0),
                    new Vector2(3, 1)
                )
            );

            batch_list.draw();
        }
    }
}
