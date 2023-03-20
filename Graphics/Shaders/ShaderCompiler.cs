using ArcadiaEngine.Graphics.OpenGL;
using System.Diagnostics;

namespace ArcadiaEngine.Graphics.Shaders {
    static class ShaderCompiler {
        public static uint compile(string code, int shader_type) {
            uint shader = GL.glCreateShader(shader_type);

            GL.glShaderSource(shader, code);
            GL.glCompileShader(shader);
            int[] status = GL.glGetShaderiv(shader, GL.GL_COMPILE_STATUS, 1);
            if (status[0] == 0) {
                // failed to compile
                string error = GL.glGetShaderInfoLog(shader);
                Debug.WriteLine("ERROR COMPILING SHADER: " + error);
            }
            
            return shader;
        }

        public static uint link(params uint[] shaders) {
            uint program = GL.glCreateProgram();
            
            foreach(uint shader in shaders) {
                GL.glAttachShader(program, shader);
            }

            GL.glLinkProgram(program);

            foreach (uint shader in shaders) {
                GL.glDetachShader(program, shader);
                GL.glDeleteShader(shader);
            }

            return program;
        }
    }
}
