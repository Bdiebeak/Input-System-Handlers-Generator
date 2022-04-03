using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bdiebeak.InterfaceGenerator
{
    public class InputActionGenerator
    {
        private const string MenuItemPath = "Assets/Bdiebeak/Input System/Generate Interfaces";

        [MenuItem(MenuItemPath)]
        private static void DoSomething()
        {
            var inputActionAsset = Selection.activeObject as InputActionAsset;
            if (inputActionAsset == null)
            {
                Debug.LogError("Can't find InputActionAsset.");
                return;
            }

            // ToDo: open folder to save separated interface for each action map (Player, UI and etc.)
            var outputPath = EditorUtility.SaveFilePanelInProject("Save location", "InputSystemInterface", "cs", "Where do you want to save.");

            var generator = new PropertiesInterfaceGenerator();
            generator.Session = new Dictionary<string, object>();

            var interfaceName = Path.GetFileNameWithoutExtension(outputPath);
            generator.Session["interfaceName"] = $"I{interfaceName}";

            var actions = new Dictionary<string, string>();
            foreach (var map in inputActionAsset.actionMaps)
            {
                foreach (var action in map.actions)
                {
                    var suitableType = action.ConvertToSuitableType();
                    if (string.IsNullOrEmpty(suitableType)) continue;
                    
                    actions.Add(action.name, suitableType);
                }
            }

            generator.Session["actions"] = actions;
            generator.Initialize();

            var generated = generator.TransformText();

            File.WriteAllText(outputPath, generated);
            AssetDatabase.Refresh();
        }

        [MenuItem(MenuItemPath, true)]
        private static bool DoSomethingValidation() => Selection.activeObject.GetType() == typeof(InputActionAsset);
    }
}