using ArcadiaEngine.Graphics.OpenGL;

namespace ArcadiaEngine.Graphics.Shaders {
    class DisplayShader : Shader {
        // Shader constructor takes a list of paths and compiles it all into a single program
        // but the paths must be places in order of all vertex shaders, then all fragment shaders.
        // Assumes that anything that isn't counted vertex shader is a fragment shader
        public DisplayShader(int vertex_shader_count, params string[] shader_paths) {
            uint[] shaders = new uint[shader_paths.Length];

            for (uint i = 0; i < vertex_shader_count; i++)
                shaders[i] = ShaderCompiler.compile(ShaderReader.read_from_file(shader_paths[i]), GL.GL_VERTEX_SHADER);
            for (int i = vertex_shader_count; i < shader_paths.Length; i++)
                shaders[i] = ShaderCompiler.compile(ShaderReader.read_from_file(shader_paths[i]), GL.GL_FRAGMENT_SHADER);

            program = ShaderCompiler.link(shaders);
        }

        public DisplayShader(params string[] shader_paths) : this(1, shader_paths) { }
    }
}
