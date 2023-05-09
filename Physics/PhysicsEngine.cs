using System.Collections.Generic;

using ArcadiaEngine.Physics.Bodies;

namespace ArcadiaEngine.Physics
{
    internal static class PhysicsEngine {
        private static List<PhysicsBody> physics_objects;

        public static void initialize() {
            physics_objects = new List<PhysicsBody>();
        }

        public static void update(params PhysicsBody[] bodies) {
            foreach(PhysicsBody body in bodies)
                physics_objects.Add(body);
        }

        public static void broad_phase() {
            foreach(PhysicsBody body_a in physics_objects)
                foreach(PhysicsBody body_b in physics_objects)
                    if(body_a != body_b && body_a.narrow_phase(body_b)) {
                        CollisionEvent collison = new CollisionEvent(
                            
                        );

                        body_a.on_collision(collison);
                        body_b.on_collision(collison);
                    }
        }
    }
}
