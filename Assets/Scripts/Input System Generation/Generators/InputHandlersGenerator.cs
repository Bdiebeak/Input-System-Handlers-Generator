using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;

namespace Bdiebeak.InputSystemGeneration
{
    public class InputHandlersGenerator
    {
        private InputActionMap _actionMap;
        private Dictionary<string, string> _actionsDictionary;

        public string CameledMapName => _actionMap.name.ToCamelCase();
        public string BaseClassName => $"{CameledMapName}InputActions";
        public string MessagesHandlerClassName => $"{CameledMapName}MessagesHandler";
        public string ActionsReaderClassName => $"{CameledMapName}ActionsReader";
        public string EnumName => $"{CameledMapName}Actions";
        
        public InputHandlersGenerator(InputActionMap actionMap)
        {
            _actionMap = actionMap;
            _actionsDictionary = GenerateActionsDictionary();
        }

        public string GenerateBaseClassCode()
        {
            var generator = new InputHandlerBaseClassTemplate { Session = new Dictionary<string, object>() };
            generator.Session["baseClassName"] = BaseClassName;
            generator.Session["actions"] = _actionsDictionary;
            generator.Initialize();

            return generator.TransformText();
        }
        
        public string GenerateActionsEnumCode()
        {
            var generator = new InputActionsEnumTemplate { Session = new Dictionary<string, object>() };
            generator.Session["enumName"] = EnumName;
            generator.Session["actions"] = _actionsDictionary.Keys.ToList();
            generator.Initialize();

            return generator.TransformText();
        }
        
        public string GenerateInputActionsReaderCode()
        {
            var generator = new InputActionsReaderTemplate { Session = new Dictionary<string, object>() };
            generator.Session["baseClassName"] = BaseClassName;
            generator.Session["className"] = ActionsReaderClassName;
            generator.Session["enumName"] = EnumName;
            generator.Session["actions"] = _actionsDictionary;
            generator.Initialize();

            return generator.TransformText();
        }
        
        public string GenerateMessageHandlerCode()
        {
            var generator = new InputMessagesHandlerTemplate { Session = new Dictionary<string, object>() };
            generator.Session["baseClassName"] = BaseClassName;
            generator.Session["className"] = MessagesHandlerClassName;
            generator.Session["actions"] = _actionsDictionary;
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