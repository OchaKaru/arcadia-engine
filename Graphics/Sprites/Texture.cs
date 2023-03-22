using System.Drawing;
using System.Numerics;
using ArcadiaEngine.Graphics.OpenGL;

namespace ArcadiaEngine.Graphics.Sprites {
    class Texture {
        public uint texture { get; }
        public Vector2 texture_size { get; }

        public unsafe Texture(string texture_path, int wrap_x_param, int wrap_y_param, int min_filter, int mag_filter) {
            Bitmap image = new Bitmap(texture_path);

            texture_size = new Vector2(image.Width, image.Height);

            byte[] data = image_byte_data(image);

            texture = GL.glGenTexture();
            GL.glBindTexture(GL.GL_TEXTURE_2D, texture);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, wrap_x_param);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, wrap_y_param);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, min_filter);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, mag_filter);
            fixed (byte* d = &data[0])
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, GL.GL_RGBA, image.Width, image.Height, 0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, d);
            GL.glGenerateMipmap(GL.GL_TEXTURE_2D);
        }

        public unsafe Texture(string texture_path) : this(texture_path, GL.GL_REPEAT, GL.GL_REPEAT, GL.GL_LINEAR_MIPMAP_LINEAR, GL.GL_LINEAR) {}

        public void set_active_and_bind(int index) {
            GL.glActiveTexture(GL.GL_TEXTURE0 + index);
            GL.glBindTexture(GL.GL_TEXTURE_2D, texture);
        }

        public static byte[] image_byte_data(Bitmap img) {
            byte[] data = new byte[4 * (img.Width * img.Height)];
            int offset = 0;
            for (int i = 0; i < img.Width; i++) {
                for (int j = img.Height - 1; j >= 0; j--) {
                    Color pixel = img.GetPixel(i, j);
                    data[offset + 0] = pixel.R;
                    data[offset + 1] = pixel.G;
                    data[offset + 2] = pixel.B;
                    data[offset + 3] = pixel.A;
                    offset += 4;
                }
            }
            return data;
        }
    }
}
