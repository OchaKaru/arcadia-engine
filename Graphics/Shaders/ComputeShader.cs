using OpenTK.Graphics.OpenGL4;

namespace ArcadiaEngine.Graphics.Shaders {
    internal class ComputeShader : Shader {
        public ComputeShader(params string[] shader_paths) {
            int[] shaders = new int[shader_paths.Length];

            for(int i = 0; i < shader_paths.Length; i++)
                shaders[i] = ShaderCompiler.compile(shader_paths[i], ShaderType.ComputeShader);

            program = ShaderCompiler.link(shaders);
        }
    }
}
