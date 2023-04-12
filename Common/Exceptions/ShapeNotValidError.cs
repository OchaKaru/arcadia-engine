using System;

namespace ArcadiaEngine.Common.Exceptions {
    internal class ShapeNotValidError : Exception {
        public ShapeNotValidError(string message) : base(message) { }
        public ShapeNotValidError() : base() { }
    }
}
