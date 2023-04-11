using System;
using System.Collections.Generic;

namespace ArcadiaEngine.Graphics.Animations {
    using ControllerDictionary = Dictionary<string, int>;

    internal class AnimatorState {
        private ControllerDictionary controllers;

        public AnimatorState(ControllerDictionary state_modifiers) {
            controllers = state_modifiers;
        }

        public int get_controller_value(string name) {
            return controllers[name];
        }

        public void set_controller_value(string name, int value) {
            controllers[name] = value;
        }

        public ControllerDictionary get_controllers() {
            return controllers;
        }

        public void add_controller(ControllerDictionary controllers_to_add) {
            if(controllers_to_add == null)
                return;

            foreach(KeyValuePair<string, int> controller in controllers_to_add) {
                try {
                    controllers.Add(controller.Key, controller.Value);
                } catch(ArgumentException) {
                    controllers[controller.Key] = controller.Value;
                }
              }
        }

        public void remove_controller(string[] controller_names) {
            foreach(string name in controller_names)
                controllers.Remove(name);
        }

        public void clear() {
            controllers.Clear();
        }
    }
}
