using System.Runtime.CompilerServices;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

using ArcadiaEngine.Common.Exceptions;

namespace ArcadiaEngine.Graphics.Sprites {
    class SpriteQuadArray {
        private const int NUMBER_OF_VERTICES = 6;

        public int vertex_array { get; set; }

        public int quad_id_buffer { get; set; }
        public int vertex_buffer { get; set; }

        public int maximum_quads { get; }

        public SpriteQuadArray(int max_quads) {
            maximum_quads = max_quads;

            vertex_array = GL.GenVertexArray();

            quad_id_buffer = GL.GenBuffer();
            vertex_buffer = GL.GenBuffer();
        }

        public void bind() {
            GL.BindVertexArray(vertex_array);
        }

        public void unbind() {
            GL.BindVertexArray(0);
        }


        private void update_quad_id_buffer(int number_of_quads) {
            GL.BindVertexArray(vertex_array);

            int[] quad_ids = new int[number_of_quads * NUMBER_OF_VERTICES];
            for(int i = 0; i < number_of_quads; i++)
                for(int j = 0; j < NUMBER_OF_VERTICES; j++)
                    quad_ids[i * NUMBER_OF_VERTICES + j] = i;

            GL.BindBuffer(BufferTarget.ArrayBuffer, quad_id_buffer);
            GL.BufferData(BufferTarget.ArrayBuffer, quad_ids.Length * sizeof(int), quad_ids, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 1, VertexAttribPointerType.Int, false, sizeof(int), 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        private void update_vertex_buffer(int number_of_quads) {
            GL.BindVertexArray(vertex_array);

            Vector2[] vertices = {
                new Vector2(0, 0),  // bottom left
                new Vector2(0, 1),  // top left
                new Vector2(1, 1),  // top right

                new Vector2(0, 0),  // bottom left
                new Vector2(1, 1),  // top right
                new Vector2(1, 0)   // bottom right
            };

            Vector2[] all_vertices = new Vector2[number_of_quads * NUMBER_OF_VERTICES];
            for(int i = 0; i < number_of_quads; i++)
                for(int j = 0; j < NUMBER_OF_VERTICES; j++)
                    all_vertices[i * NUMBER_OF_VERTICES + j] = vertices[j];


            GL.BindBuffer(BufferTarget.ArrayBuffer, vertex_buffer);
            GL.BufferData(BufferTarget.ArrayBuffer, Unsafe.SizeOf<Vector2>() * all_vertices.Length, all_vertices, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void render(int number_of_quads = 0) {
            if(number_of_quads > maximum_quads)
                throw new InvalidLengthError("ARCADIA ENGINE ERROR: The number of quads is larger than the maximum.");
            
            number_of_quads = number_of_quads == 0 ? maximum_quads : number_of_quads;

            update_quad_id_buffer(number_of_quads);
            update_vertex_buffer(number_of_quads);

            GL.BindVertexArray(vertex_array);
            GL.DrawArrays(PrimitiveType.Triangles, 0, number_of_quads * NUMBER_OF_VERTICES);
            GL.BindVertexArray(0);
        }
    }
}
