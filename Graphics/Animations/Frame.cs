using System.Collections.Generic;

using OpenTK.Mathematics;


namespace ArcadiaEngine.Graphics.Animations {
    internal class Frame {
        public Vector2 frame_coordinates { get; }
        
        private Dictionary<string, AnimationController> controllers;
    }
}
