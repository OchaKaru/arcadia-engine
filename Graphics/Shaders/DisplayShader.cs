using OpenGL;

namespace ArcadiaEngine.Graphics.Shaders {
    class DisplayShader : Shader {
        // Shader constructor takes a list of paths and compiles it all into a single program
        // but the paths must be places in order of all vertex shaders, then all fragment shaders.
        // Assumes that anything that isn't counted vertex shader is a fragment shader
        public DisplayShader(string vertex_shader_path, string fragment_shader_path) {
            uint vertex_shader = ShaderCompiler.compile(ShaderReader.read_from_file(vertex_shader_path), ShaderType.VertexShader);
            uint fragment_shader = ShaderCompiler.compile(ShaderReader.read_from_file(fragment_shader_path), ShaderType.FragmentShader);

            program = ShaderCompiler.link(vertex_shader, fragment_shader);
        }
    }
}
