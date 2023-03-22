using ArcadiaEngine.Graphics.Shaders;
using ArcadiaEngine.Graphics.OpenGL;
using System.Numerics;

namespace ArcadiaEngine.Graphics.Sprites {
    static class SpriteRenderer {
        private static Shader shader;
        private static Camera camera_pointer;
        private static uint vertex_array;

        unsafe public static void initialize(Camera camera) {
            shader = new Shader(
                @"C:\Users\Plutarco\Documents\Documents\Projects\arcadia-engine\test-shaders\sprite-renderer-vertex.glsl", 
                @"C:\Users\Plutarco\Documents\Documents\Projects\arcadia-engine\test-shaders\sprite-renderer-fragment.glsl"
            );
            camera_pointer = camera;

            vertex_array = GL.glGenVertexArray();
            GL.glBindVertexArray(vertex_array);

            uint vertex_buffer = GL.glGenBuffer();
            float[] vertices = {
                // position // texture
                0.0f, 1.0f, 0.0f, 0.0f, // top left
                1.0f, 0.0f, 1.0f, 1.0f, // bottom right
                0.0f, 0.0f, 1.0f, 0.0f, // bottom left

                0.0f, 1.0f, 0.0f, 0.0f, //top left
                1.0f, 1.0f, 0.0f, 1.0f, // top right
                1.0f, 0.0f, 1.0f, 1.0f  // bottom right
            };
            GL.glBindBuffer(GL.GL_ARRAY_BUFFER, vertex_buffer);
            fixed (float* v = &vertices[0])
                GL.glBufferData(GL.GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL.GL_STATIC_DRAW);

            GL.glVertexAttribPointer(0, 2, GL.GL_FLOAT, false, 4 * sizeof(float), (void*)0);
            GL.glEnableVertexAttribArray(0);
            GL.glVertexAttribPointer(1, 2, GL.GL_FLOAT, false, 4 * sizeof(float), (void*)(2 * sizeof(float)));
            GL.glEnableVertexAttribArray(1);

            GL.glBindBuffer(GL.GL_ARRAY_BUFFER, 0);
            GL.glBindVertexArray(0);
        }

        unsafe public static void draw(Sprite sprite) {
            shader.use();

            Matrix4x4 translation = Matrix4x4.CreateTranslation(sprite.sprite_position.X, sprite.sprite_position.Y, 0);
            Matrix4x4 scale = Matrix4x4.CreateScale(sprite.sprite_scale.X, sprite.sprite_scale.Y, 1);
            Matrix4x4 rotation = Matrix4x4.CreateRotationZ(sprite.sprite_rotation);

            shader.set_matrix_4x4("model", scale * rotation * translation);
            shader.set_matrix_4x4("projection", camera_pointer.get_projection_matrix());
            shader.set_vector_4("color", sprite.sprite_color);

            shader.set_int("image", 0);
            sprite.set_active_and_bind(0);
            
            GL.glBindVertexArray(vertex_array);
            GL.glDrawArrays(GL.GL_TRIANGLES, 0, 6);
            GL.glBindVertexArray(0);
        }
    }
}
