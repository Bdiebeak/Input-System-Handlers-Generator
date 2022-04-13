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

        public string CamaledMapName => _actionMap.name.ToCamelCase();
        public string BaseClassName => $"{CamaledMapName}InputActions";
        public string ClassName => $"{CamaledMapName}MapInputHandler";
        
        public string GenerateInterfaceCode()
        {
            var generator = new InputHandlerBaseClassTemplate { Session = new Dictionary<string, object>() };
            generator.Session["baseClassName"] = BaseClassName;
            generator.Session["actions"] = GenerateActionsDictionary();
            generator.Initialize();

            return generator.TransformText();
        }
        
        public string GenerateHandlerClassCode()
        {
            var generator = new InputMessagesHandlerTemplate { Session = new Dictionary<string, object>() };
            generator.Session["baseClassName"] = BaseClassName;
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
                    
                actions.Add(action.name.ToCamelCase(), suitableType);
            }

            return actions;
        }
    }
}