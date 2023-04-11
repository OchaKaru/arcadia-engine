using System;

using OpenTK.Mathematics;

using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics.Sprites;

namespace ArcadiaEngine.Physics {
    public abstract class VerletEntity : Entity {
        public Vector2 old_entity_position { get; set; }
        public Vector2 entity_acceleration { get; set; }

        public override void move() {
            Vector2 temp = entity_position;
            entity_position = 2 * entity_position - old_entity_position + entity_acceleration * MathF.Pow(Timer.delta_time, 2);
            old_entity_position = temp;
        }
    }
}
