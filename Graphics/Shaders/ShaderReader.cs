using System.IO;

namespace ArcadiaEngine.Graphics.Shaders {
    static class ShaderReader {
        public static string read_from_file(string shader_path) {
            StreamReader file = File.OpenText(shader_path);

            string code = file.ReadToEnd();
            
            file.Close();

            return code;
        }
    }
}
