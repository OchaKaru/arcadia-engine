using System.IO;
using System.Numerics;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;
using OpenGL;
using static OpenGL.Gl;
using static GLFW.Glfw;

using ArcadiaEngine.Graphics.Sprites;

namespace ArcadiaEngine.Graphics {
    static class Renderer { // Game Renderer
        private static Camera camera;
        private static Dictionary<string, SpriteInfo> sprite_table;

        public static Vector4 background_color { get; set; }

        private static void load_sprites() {
            /*
            if (!File.Exists(Settings.sprite_info_file))
                throw new FileNotFoundException("ARCADIA ENGINE ERROR: Could not find settings information file.");
            if (Path.GetExtension(Settings.sprite_info_file) != ".json")
                throw new FileLoadException("ARCADIA ENGINE ERROR: Could not load file because it is not of type JSON.");
            JObject sprite_info = JObject.Parse(File.ReadAllText(Settings.sprite_info_file));

            sprite_table = new Dictionary<string, SpriteInfo>();

            foreach(var sprite in sprite_info)
                sprite_table.Add(sprite.Key, sprite.Value.ToObject<SpriteInfo>());
            */
        }

        unsafe public static void initialize() {
            Enable(EnableCap.Blend);
            BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            camera = new Camera(WindowManager.window_size / 2.0f, 1.0f);

            load_sprites();
        }

        public static void draw() {

        }

        public static void clear_color() {
            ClearColor(background_color.X, background_color.Y, background_color.Z, background_color.W);
            Clear(ClearBufferMask.ColorBufferBit);
        }

        public static void swap_buffers() {
            SwapBuffers(WindowManager.window);
        }
    }
}
