using System.Collections.Generic;

using OpenTK.Mathematics;


namespace ArcadiaEngine.Graphics.Animations {
    using ControllerDictionary = Dictionary<string, int>;

    internal class Frame {
        public Vector2 frame_coordinates { get; }
        
        public readonly ControllerDictionary controllers;

        public Frame(Vector2 coordinate, ControllerDictionary state_modifiers) {
            frame_coordinates = coordinate;
            controllers = state_modifiers;
        }
    }
}
