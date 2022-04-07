using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Bdiebeak.InputSystemGeneration
{
    public class InputHandlersGenerator
    {
        private InputActionMap _actionMap;
        
        public InputHandlersGenerator(InputActionMap actionMap)
        {
            _actionMap = actionMap;
        }

        public string MapName => _actionMap.name;
        public string InterfaceName => $"I{_actionMap.name}InputActions";
        public string ClassName => $"{_actionMap.name}MapInputHandler";
        
        public string GenerateInterfaceCode()
        {
            var generator = new InputSystemInterfaceTemplate { Session = new Dictionary<string, object>() };
            generator.Session["interfaceName"] = InterfaceName;
            generator.Session["actions"] = GenerateActionsDictionary();
            generator.Initialize();

            return generator.TransformText();
        }
        
        public string GenerateHandlerClassCode()
        {
            var generator = new InputHandlerClassTemplate { Session = new Dictionary<string, object>() };
            generator.Session["interfaceName"] = InterfaceName;
            generator.Session["className"] = ClassName;
            generator.Session["actions"] = GenerateActionsDictionary();
            generator.Initialize();

            return generator.TransformText();
        }
        
        private Dictionary<string, string> GenerateActionsDictionary()
        {
            var actions = new Dictionary<string, string>();
            foreach (var action in _actionMap.actions)
            {
                var suitableType = action.ConvertToSuitableType();
                if (string.IsNullOrEmpty(suitableType)) continue;
                    
                actions.Add(action.name, suitableType);
            }

            return actions;
        }
    }
}