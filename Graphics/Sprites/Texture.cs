using System.IO;
using System.Runtime.CompilerServices;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

using ArcadiaEngine.Common.Exceptions;

namespace ArcadiaEngine.Graphics.Sprites {
    class Texture {
        public int texture { get; }
        public Vector2 texture_size { get; }

        public Texture(string texture_path, TextureWrapMode wrap_x_param, TextureWrapMode wrap_y_param, TextureMinFilter min_filter, TextureMagFilter mag_filter) {
            (byte[] data, texture_size) = image_data(texture_path);
            
            texture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)wrap_x_param);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)wrap_y_param);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)min_filter);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)mag_filter);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int)texture_size.X, (int)texture_size.Y, 0, PixelFormat.Rgba, PixelType.UnsignedByte, data);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public Texture(string texture_path) : this(texture_path, TextureWrapMode.Repeat, TextureWrapMode.Repeat, TextureMinFilter.Nearest, TextureMagFilter.Nearest) { }

        public void bind(int index) {
            GL.ActiveTexture(TextureUnit.Texture0 + index);
            GL.BindTexture(TextureTarget.Texture2D, texture);
        }

        public void bind() {
            GL.BindTexture(TextureTarget.Texture2D, texture);
        }

        public static (byte[], Vector2) image_data(string texture_path) {
            if(File.Exists(texture_path) is not true)
                throw new FileNotFoundException("ARCADIA ENGINE ERROR: The image file specified could not be found.");
            Image<Rgba32> image = Image.Load<Rgba32>(texture_path) ?? throw new ImageNotLoadedError("ARCADIA ENGINE ERROR: The texture image at the path specified could not be loaded.");

            byte[] data = new byte[Unsafe.SizeOf<Rgba32>() * (image.Width * image.Height)];
            image.CopyPixelDataTo(data);

            return (data, new Vector2(image.Width, image.Height));
        }
    }
}
