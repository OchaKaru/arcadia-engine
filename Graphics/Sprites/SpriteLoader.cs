using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ArcadiaEngine.Common;

namespace ArcadiaEngine.Graphics.Sprites {
    static class SpriteLoader {
        public static Dictionary<string, SpriteBatch> load_sprites() {
            if(File.Exists(Settings.sprite_info_file) is not true)
                throw new FileNotFoundException("ARCADIA ENGINE ERROR: Could not find sprite-info.json file.");

            JObject sprite_info = JObject.Parse(File.ReadAllText(Settings.sprite_info_file)) ?? throw new FileLoadException("ARCADIA ENGINE ERROR: Could not load the sprite-info.json file.");

            Dictionary<string, SpriteBatch> batches = new Dictionary<string, SpriteBatch>();

            foreach(KeyValuePair<string, JToken> token in sprite_info) {
                batches.Add(token.Key, new SpriteBatch(token.Value.ToString()));
            }

            return batches;
        }
    }
}
