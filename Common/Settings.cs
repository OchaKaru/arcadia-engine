﻿using System;
using System.IO;
using System.Runtime.CompilerServices;

using Newtonsoft.Json.Linq;
using OpenTK.Mathematics;

namespace ArcadiaEngine.Common {
    internal static class Settings {
        private static string settings_file = @"C:\Users\Plutarco\Documents\Documents\Projects\game-engine\test-game\engine_settings.json";
        public static string window_name { get; set; }
        public static Vector2 window_size { get; set; }
        public static int vsync { get; set; }
        public static Vector4 default_background_color { get; set; }

        public static bool enable_camera_zoom { get; set; }
        public static bool enable_camera_follow { get; set; }

        public static string sprite_info_file { get; set; }

        public static void load() {
            //int attempt = 0;
            //string base_directory = "./";

            //while(attempt < 3) {
            //    settings_file = Directory.GetFiles(base_directory, "engine_settings.json")[0];
            //    base_directory += "../";
            //}

            //Console.WriteLine(settings_file);

            if(File.Exists(settings_file) is not true)
                throw new FileNotFoundException("ARCADIA ENGINE ERROR: Could not find settings.json file.");

            JObject settings = JObject.Parse(File.ReadAllText(settings_file)) ?? throw new FileLoadException("ARCADIA ENGINE ERROR: Could not load the setting.json file.");

            if(settings["windowName"] is not null)
                window_name = settings["windowName"].ToObject<string>() ?? "Arcadia Engine Game Window";
            if(settings["windowSize"] is not null && settings["windowSize"]["X"] is not null && settings["windowSize"]["Y"] is not null)
                window_size = new Vector2(settings["windowSize"]["X"].ToObject<float>(), settings["windowSize"]["Y"].ToObject<float>());
            else
                window_size = new Vector2(800, 600);
            if(settings["vSync"] != null)
                vsync = settings["vSync"].ToObject<int>();
            else
                vsync = 0;
            if(settings["defaultBackgroundColor"] is not null)
                default_background_color = new Vector4(
                    settings["defaultBackgroundColor"][0].ToObject<float>(),
                    settings["defaultBackgroundColor"][1].ToObject<float>(),
                    settings["defaultBackgroundColor"][2].ToObject<float>(),
                    settings["defaultBackgroundColor"][3].ToObject<float>()
                );
            else
                default_background_color = new Vector4(0);

            if(settings["enableCameraZoom"] is not null)
                enable_camera_zoom = settings["enableCameraZoom"].ToObject<bool>();
            else
                enable_camera_zoom = false;
            if(settings["enableCameraFollow"] is not null)
                enable_camera_follow = settings["enableCameraFollow"].ToObject<bool>();
            else
                enable_camera_follow = false;


            if(settings["spriteInfoFile"] is not null)
            sprite_info_file = settings["spriteInfoFile"].ToObject<string>() ?? "sprite-info.json";
        }

        public static void save() {
            JObject settings = new JObject(
                new JProperty("windowName", window_name),
                new JProperty("windowSize", new JObject(
                    new JProperty("X", window_size.X),
                    new JProperty("Y", window_size.Y)
                )),
                new JProperty("vSync", vsync),
                new JProperty("spriteInfoFile", sprite_info_file),
                new JProperty("enableCameraZoom", enable_camera_zoom),
                new JProperty("enableCameraFollow", enable_camera_follow)
            );

            File.WriteAllText(settings_file, settings.ToString());
        }
    }
}
