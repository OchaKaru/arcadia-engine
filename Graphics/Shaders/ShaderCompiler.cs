using System.Diagnostics;
using System.Text;

using OpenGL;
using static OpenGL.Gl;

namespace ArcadiaEngine.Graphics.Shaders {
    static class ShaderCompiler {
        private const int MAX_ERROR_LENGTH = 1000;

        public static uint compile(string code, ShaderType shader_type) {
            uint shader = CreateShader(shader_type);

            ShaderSource(shader, new string[] { code });
            CompileShader(shader);
            GetShader(shader, ShaderParameterName.CompileStatus, out int status);
            if (status == 0) {
                // failed to compile
                StringBuilder error = new StringBuilder();
                GetShaderInfoLog(shader, MAX_ERROR_LENGTH, out _, error);
                Debug.WriteLine("ERROR COMPILING SHADER: " + error);
            }
            
            return shader;
        }

        public static uint link(params uint[] shaders) {
            uint program = CreateProgram();
            
            foreach(uint shader in shaders) {
                AttachShader(program, shader);
            }

            LinkProgram(program);

            foreach (uint shader in shaders) {
                DetachShader(program, shader);
                DeleteShader(shader);
            }

            return program;
        }
    }
}
