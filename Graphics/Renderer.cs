using System;

using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics.Shaders;
using ArcadiaEngine.Graphics.Sprites;

namespace ArcadiaEngine.Graphics {
    class Renderer {
        public static Camera camera { get; set; }

        public static Vector4 background_color { get; set; }

        public static Shader shader { get; }
        public SpriteQuadArray quads { get; set; }

        public static void initialize() {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            Console.WriteLine(GL.GetString(StringName.Version), GL.GetString(StringName.Renderer), GL.GetString(StringName.Vendor));

            camera = new Camera(WindowManager.window_size / 2.0f, 1.0f);
        }

        public static void clear_color() {
            GL.ClearColor(background_color.X, background_color.Y, background_color.Z, background_color.W);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public static void initialize_quads() {

        }

        public static void draw(params Entity[] entity) {
            
        }
    }
}
