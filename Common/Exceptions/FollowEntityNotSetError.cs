using System;

namespace ArcadiaEngine.Common.Exceptions {
    internal class FollowEntityNotSetError : Exception {
        public FollowEntityNotSetError(string message) : base(message) { }
        public FollowEntityNotSetError() : base() { }
    }
}
