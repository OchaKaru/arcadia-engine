using ArcadiaEngine.Graphics.OpenGL;

namespace ArcadiaEngine.Graphics.Shaders {
    class ComputeShader : Shader {
        public ComputeShader(params string[] shader_paths) {
            uint[] shaders = new uint[shader_paths.Length];

            for(int i = 0; i < shader_paths.Length; i++)
                shaders[i] = ShaderCompiler.compile(ShaderReader.read_from_file(shader_paths[i]), GL.GL_VERTEX_SHADER);

            program = ShaderCompiler.link(shaders);
        }
    }
}
