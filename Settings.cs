using System.Numerics;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ArcadiaEngine {
    static class Settings {
        const string settings_file = @"C:\Users\Plutarco\Documents\Documents\Projects\arcadia-engine\settings.json";

        public static string window_name { get; set; }
        public static Vector2 window_size {get; set;}
        public static int vsync { get; set; }

        public static string vertex_shader_file { get; set; }
        public static string fragment_shader_file { get; set; }

        public static string sprite_info_file { get; set; }

        public static void load() {
            if (!File.Exists(settings_file))
                throw new FileNotFoundException("ARCADIA ENGINE ERROR: Could not find settings.json file.");
            JObject settings = JObject.Parse(File.ReadAllText(settings_file));

            window_name = settings["windowName"].ToObject<string>();
            window_size = new Vector2(settings["windowSize"]['X'].ToObject<float>(), settings["windowSize"]['Y'].ToObject<float>());
            vsync = settings["vSync"].ToObject<int>();

            vertex_shader_file = settings["vertexShaderFile"].ToObject<string>();
            fragment_shader_file = settings["fragmentShaderFile"].ToObject<string>();

            sprite_info_file = settings["spriteInfoFile"].ToObject<string>();
        }

        public static void save() {
            JObject settings = new JObject(
                new JProperty("windowName", window_name),
                new JProperty("windowSize", new JObject(
                    new JProperty("X", window_size.X),
                    new JProperty("Y", window_size.Y)
                )),
                new JProperty("vSync", vsync),
                new JProperty("vertexShaderFile", vertex_shader_file),
                new JProperty("fragmentShaderFile", fragment_shader_file),
                new JProperty("spriteInfoFile", sprite_info_file)
            );

            File.WriteAllText(settings_file, settings.ToString());
        }
    }
}
