using System.Numerics;

using static OpenGL.Gl;

namespace ArcadiaEngine.Graphics.Shaders {
    abstract class Shader {
        public uint program { get; set; }

        public void use() {
            UseProgram(program);
        }

        public void set_uint(string uniform_name, uint value) {
            int location = GetUniformLocation(program, uniform_name);
            Uniform1(location, value);
        }

        public void set_int(string uniform_name, int value) {
            int location = GetUniformLocation(program, uniform_name);
            Uniform1(location, value);
        }

        public void set_float(string uniform_name, float value) {
            int location = GetUniformLocation(program, uniform_name);
            Uniform1(location, value);
        }

        public void set_matrix_4x4(string uniform_name, Matrix4x4 matrix) {
            int location = GetUniformLocation(program, uniform_name);
            UniformMatrix4(location, false, get_matrix_4x4_values(matrix));
        }

        public void set_vector_4(string uniform_name, Vector4 vector) {
            int location = GetUniformLocation(program, uniform_name);
            Uniform4(location, vector.X, vector.Y, vector.Z, vector.W);
        }

        private static float[] get_matrix_4x4_values(Matrix4x4 matrix) {
            return new float[] {
                matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                matrix.M41, matrix.M42, matrix.M43, matrix.M44
            };
        }
    }
}
