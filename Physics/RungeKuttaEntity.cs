using System;

using OpenTK.Mathematics;

using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics.Sprites;

namespace ArcadiaEngine.Physics {
    public abstract class RungeKuttaEntity : Entity {
        public Vector2 entity_velocity { get; set; }
        public Vector2 entity_acceleration { get; set; }

        public override void move() {
            
        }
    }
}
