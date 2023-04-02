using OpenTK.Graphics.OpenGL4;

namespace ArcadiaEngine.Graphics.Shaders {
    public class DisplayShader : Shader {
        public DisplayShader(string vertex_shader_path, string fragment_shader_path) {
            int vertex_shader = ShaderCompiler.compile(vertex_shader_path, ShaderType.VertexShader);
            int fragment_shader = ShaderCompiler.compile(fragment_shader_path, ShaderType.FragmentShader);

            program = ShaderCompiler.link(vertex_shader, fragment_shader);
        }
    }
}
