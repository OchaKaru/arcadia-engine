using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using OpenTK.Graphics.OpenGL4;

namespace ArcadiaEngine.Graphics.Sprites {
    class SpriteBatch {
        public Texture sprite_sheet { get; set; }
        public SpriteQuadManager quads { get; set; }

        public int sprite_info_buffer { get; set; }
        private List<SpriteInfo> sprites;

        public SpriteBatch(string sprite_sheet_path) {
            sprite_sheet = new Texture(sprite_sheet_path);
            quads = new SpriteQuadManager(100);

            sprite_info_buffer = GL.GenBuffer();
            sprites = new List<SpriteInfo>();
        }

        public void add_sprite(params SpriteInfo[] sprites_to_add) {
            foreach(SpriteInfo sprite in sprites_to_add)
                sprites.Add(sprite);
        }

        private void bind_sprite_info() {
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, sprite_info_buffer);
            GL.BufferData(BufferTarget.ShaderStorageBuffer, sprites.Count * Unsafe.SizeOf<SpriteInfo>(), sprites.ToArray(), BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, 0);
            GL.BindBufferBase(BufferRangeTarget.ShaderStorageBuffer, 2, sprite_info_buffer);
        }

        public void draw() {
            bind_sprite_info();

            sprite_sheet.bind(0);
            quads.render(sprites.Count);
            sprites.Clear();
        }
    }
}
