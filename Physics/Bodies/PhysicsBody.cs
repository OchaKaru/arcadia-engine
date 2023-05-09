using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaEngine.Physics.Bodies {
    public abstract class PhysicsBody {
        public Vector2 current_position;
        public Hitbox hitbox;

        internal Action<CollisionEvent> on_collision;

        public PhysicsBody(Vector2 initial_position) {
            current_position = initial_position;
        }

        public bool narrow_phase(PhysicsBody other) {
            return hitbox.intersects(other.hitbox);
        }

        public abstract void update_position();
    }
}
