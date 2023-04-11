using OpenTK.Mathematics;

using ArcadiaEngine.Common;
using ArcadiaEngine.Graphics.Sprites;
using System;

namespace ArcadiaEngine.Physics {
    public abstract class EulerEntity : Entity {
        public Vector2 entity_velocity { get; set; }
        public Vector2 entity_acceleration { get; set; }

        public EulerEntity(Vector2 initial_position, Vector2 initial_velocity, Vector2 initial_acceleration) {
            entity_position = initial_position;
            entity_velocity = initial_velocity;
            entity_acceleration = initial_acceleration;

            draw_layer = 0;
            dead = false;

            entity_scale = Vector2.One;
            entity_rotation = 0;
            entity_color = Vector4.One;
        }

        public override void move() {
            entity_position += entity_velocity * Timer.delta_time + 0.5f * entity_acceleration * MathF.Pow(Timer.delta_time, 2);
            entity_velocity += entity_acceleration * Timer.delta_time;
        }
    }
}
