using System.Numerics;

namespace ArcadiaEngine.Graphics.Sprites {
    class Sprite : Texture {
        // sprite position in the world
        public Vector2 sprite_position { get; set; }
        public Vector2 sprite_scale { get; set; }
        public float sprite_rotation { get; set; }

        public Vector4 sprite_color { get; set; }

        public Sprite(string sprite_path, Vector2 initial_position, Vector2 scale, float rotation, Vector4 color) : base(sprite_path) {
            sprite_position = initial_position;
            sprite_scale = scale;
            sprite_rotation = rotation;

            sprite_color = color;
        }

        public Sprite(string sprite_path, Vector2 initial_position, Vector2 scale, float rotation) : 
            this(sprite_path, initial_position, scale, rotation, new Vector4(1.0f, 1.0f, 1.0f, 0.0f)) {}

        public Sprite(string sprite_path, Vector2 initial_position) :
            this(sprite_path, initial_position, new Vector2(1.0f, 1.0f), 0.0f, new Vector4(1.0f, 1.0f, 1.0f, 0.0f)) {}

    }
}
