using ArcadiaEngine.Graphics.OpenGL;
using System.Numerics;

namespace ArcadiaEngine.Graphics.Shaders {
    class Shader {
        public uint program { get; set; }

        // Shader constructor takes a list of paths and compiles it all into a single program
        // but the paths must be places in order of all vertex shaders, then all fragment shaders.
        // Assumes that anything that isn't counted vertex shader is a fragment shader
        public Shader(int vertex_shader_count, params string[] shader_paths) {
            uint[] shaders = new uint[shader_paths.Length];

            for(uint i = 0; i < vertex_shader_count; i++)
                shaders[i] = ShaderCompiler.compile(ShaderReader.read_from_file(shader_paths[i]), GL.GL_VERTEX_SHADER);
            for (int i = vertex_shader_count; i < shader_paths.Length; i++)
                shaders[i] = ShaderCompiler.compile(ShaderReader.read_from_file(shader_paths[i]), GL.GL_FRAGMENT_SHADER);

            program = ShaderCompiler.link(shaders);
        }

        public Shader(params string[] shader_paths) : this(1, shader_paths) {}

        public void use() {
            GL.glUseProgram(program);
        }

        public void set_uint(string uniform_name, uint value) {
            int location = GL.glGetUniformLocation(program, uniform_name);
            GL.glUniform1ui(location, value);
        }

        public void set_int(string uniform_name, int value) {
            int location = GL.glGetUniformLocation(program, uniform_name);
            GL.glUniform1i(location, value);
        }

        public void set_float(string uniform_name, float value) {
            int location = GL.glGetUniformLocation(program, uniform_name);
            GL.glUniform1f(location, value);
        }

        public void set_matrix_4x4(string uniform_name, Matrix4x4 matrix) {
            int location = GL.glGetUniformLocation(program, uniform_name);
            GL.glUniformMatrix4fv(location, 1, false, _get_matrix_4x4_values(matrix));
        }

        private float[] _get_matrix_4x4_values(Matrix4x4 matrix) {
            return new float[]
            {
                matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                matrix.M41, matrix.M42, matrix.M43, matrix.M44
            };
        }
    }
}
