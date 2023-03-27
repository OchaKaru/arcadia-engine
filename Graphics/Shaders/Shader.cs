using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace ArcadiaEngine.Graphics.Shaders {
    abstract class Shader {
        public int program { get; set; }

        public void use() {
            GL.UseProgram(program);
        }

        public void set_uniform(string uniform_name, uint value) {
            int location = GL.GetUniformLocation(program, uniform_name);
            GL.Uniform1(location, value);
        }
        public void set_uniform(string uniform_name, int value) {
            int location = GL.GetUniformLocation(program, uniform_name);
            GL.Uniform1(location, value);
        }
        public void set_uniform(string uniform_name, float value) {
            int location = GL.GetUniformLocation(program, uniform_name);
            GL.Uniform1(location, value);
        }

        public void set_matrix(string uniform_name, Matrix4 matrix) {
            int location = GL.GetUniformLocation(program, uniform_name);
            GL.UniformMatrix4(location, false, ref matrix);
        }

        public void set_vector(string uniform_name, Vector2 vector) {
            int location = GL.GetUniformLocation(program, uniform_name);
            GL.Uniform2(location, vector.X, vector.Y);
        }
        public void set_vector(string uniform_name, Vector3 vector) {
            int location = GL.GetUniformLocation(program, uniform_name);
            GL.Uniform3(location, vector.X, vector.Y, vector.Z);
        }
        public void set_vector(string uniform_name, Vector4 vector) {
            int location = GL.GetUniformLocation(program, uniform_name);
            GL.Uniform4(location, vector.X, vector.Y, vector.Z, vector.W);
        }
    }
}
