using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Common.Exceptions
{
    class ShaderCompileError : Exception
    {
        public ShaderCompileError() : base() { }
        public ShaderCompileError(string message) : base(message) { }
    }
}
