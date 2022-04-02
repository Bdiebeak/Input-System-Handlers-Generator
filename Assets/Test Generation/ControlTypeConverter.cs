using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bdiebeak.InterfaceGenerator
{
    public static class ControlTypeConverter
    {
        // In Input system package we have inconvenient for type determination code.
        // It's even uncomfortable for C# Reflection. So this dictionary is the most convenient solution in my opinion.
        // ToDo: extract this dictionary into some Scriptable object settings file.
        private static Dictionary<string, string> _typeToSuitable = new Dictionary<string, string>()
        {
            {"button", "bool"},
            {"axis", "float"},
            {nameof(Vector2).ToLower(), nameof(Vector2)},
            {nameof(Vector3).ToLower(), nameof(Vector3)},
        };

        public static string ConvertToSuitableType(this InputAction inputAction)
        {
            var controlType = inputAction.expectedControlType;
            var loweredControlType = controlType.ToLower();

            foreach (var control in inputAction.controls)
            {
                Debug.Log($"{inputAction.name} | {inputAction.type} | {control.valueType.Name}");
            }

            return _typeToSuitable.ContainsKey(loweredControlType) ? _typeToSuitable[loweredControlType] : string.Empty;
        }
    }
}