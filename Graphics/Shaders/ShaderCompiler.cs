using System.IO;

using OpenTK.Graphics.OpenGL4;

using ArcadiaEngine.Common.Exceptions;

namespace ArcadiaEngine.Graphics.Shaders {
    static class ShaderCompiler {
        private const int MAX_ERROR_LENGTH = 1000;

        private static string read_from_file(string shader_path) {
            if(File.Exists(shader_path) is not true)
                throw new FileNotFoundException("ARCADIA ENGINE ERROR: The shader file could not be found.");
            string code = File.ReadAllText(shader_path) ?? throw new FileLoadException("ARCADIA ENGINE ERROR: The shader file could not be loaded.");

            return code;
        }

        public static int compile(string shader_path, ShaderType shader_type) {
            string code = read_from_file(shader_path);
            int shader = GL.CreateShader(shader_type);

            GL.ShaderSource(shader, code);
            GL.CompileShader(shader);
            GL.GetShader(shader, ShaderParameter.CompileStatus, out int status);
            if(status == 0) {
                // failed to compile
                GL.GetShaderInfoLog(shader, MAX_ERROR_LENGTH, out _, out string error);
                throw new ShaderCompileError("ERROR COMPILING SHADER: " + error);
            }

            return shader;
        }

        public static int link(params int[] shaders) {
            int program = GL.CreateProgram();

            foreach(int shader in shaders) {
                GL.AttachShader(program, shader);
            }

            GL.LinkProgram(program);

            foreach(int shader in shaders) {
                GL.DetachShader(program, shader);
                GL.DeleteShader(shader);
            }

            return program;
        }
    }
}
