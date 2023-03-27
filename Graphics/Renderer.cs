using System.Collections.Generic;
using System;
using System.IO;

using Newtonsoft.Json.Linq;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace ArcadiaEngine.Graphics {
    class Renderer {
        public static Camera camera { get; set; }
        //public static Dictionary<string, Animator> sprite_table { get; set; }

        public static Vector4 background_color { get; set; }

        private static void load_sprites() {
            //if(!File.Exists(Settings.sprite_info_file))
            //    throw new FileNotFoundException("ARCADIA ENGINE ERROR: Could not find settings information file.");
            //if(Path.GetExtension(Settings.sprite_info_file) != ".json")
            //    throw new FileLoadException("ARCADIA ENGINE ERROR: Could not load file because it is not of type JSON.");
            //JObject sprite_info = JObject.Parse(File.ReadAllText(Settings.sprite_info_file));
        }

        public static void initialize() {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            Console.WriteLine(GL.GetString(StringName.Version), GL.GetString(StringName.Renderer), GL.GetString(StringName.Vendor));

            camera = new Camera(WindowManager.window_size / 2.0f, 1.0f);

            load_sprites();
        }

        public static void clear_color() {
            GL.ClearColor(background_color.X, background_color.Y, background_color.Z, background_color.W);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }
    }
}
