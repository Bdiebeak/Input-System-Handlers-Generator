using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bdiebeak.InterfaceGenerator
{
    public class InputActionGenerator
    {
        private const string MenuItemPath = "Assets/Bdiebeak/Input System/Generate Input Scripts";

        [MenuItem(MenuItemPath, true)]
        private static bool GenerateInterfacesMenuValidation() => Selection.activeObject.GetType() == typeof(InputActionAsset);
        
        [MenuItem(MenuItemPath)]
        private static void GenerateInterfaces()
        {
            var inputActionAsset = Selection.activeObject as InputActionAsset;
            if (inputActionAsset == null)
            {
                Debug.LogError("Can't find InputActionAsset.");
                return;
            }

            var selectedFolderPath = EditorUtility.OpenFolderPanel("Save location", "InputSystemInterface", "");
            foreach (var map in inputActionAsset.actionMaps) GenerateInterfaceFromActionMap(map, selectedFolderPath);

            AssetDatabase.Refresh();
        }

        private static void GenerateInterfaceFromActionMap(InputActionMap actionMap, string folderPath)
        {
            var mapName = actionMap.name;
            var interfaceName = $"I{mapName}InputActions";
                
            var generator = new PropertiesInterfaceGenerator { Session = new Dictionary<string, object>() };
            generator.Session["interfaceName"] = interfaceName;

            // Fill actions from map
            var actions = new Dictionary<string, string>();
            foreach (var action in actionMap.actions)
            {
                var suitableType = action.ConvertToSuitableType();
                if (string.IsNullOrEmpty(suitableType)) continue;
                    
                actions.Add(action.name, suitableType);
            }
            generator.Session["actions"] = actions;
            generator.Initialize();

            // Create directory
            var directoryPath = $"{folderPath}/{mapName}";
            Directory.CreateDirectory(directoryPath);
            
            // Create and write text inside file
            var filePath = $"{directoryPath}/{interfaceName}.cs";
            File.WriteAllText(filePath, generator.TransformText());
        }
    }
}