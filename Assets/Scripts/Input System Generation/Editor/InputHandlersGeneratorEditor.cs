using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bdiebeak.InputSystemGeneration
{
    public class InputHandlersGeneratorEditor
    {
        private const string MenuItemPath = "Assets/Bdiebeak/Input System/Generate Input Handlers";

        [MenuItem(MenuItemPath, true)]
        private static bool GenerateMenuValidation() => Selection.activeObject.GetType() == typeof(InputActionAsset);
        
        [MenuItem(MenuItemPath)]
        private static void Generate()
        {
            var inputActionAsset = Selection.activeObject as InputActionAsset;
            if (inputActionAsset == null)
            {
                Debug.LogError("Can't find InputActionAsset.");
                return;
            }

            // ToDo: add warning tab if file already exists.
            var selectedFolderPath = EditorUtility.OpenFolderPanel("Save location", $"{Application.dataPath}", "");
            if (string.IsNullOrEmpty(selectedFolderPath)) return;
            
            foreach (var map in inputActionAsset.actionMaps)
            {
                var generator = new InputHandlersGenerator(map);
                var interfaceCode = generator.GenerateBaseClassCode();
                var enumCode = generator.GenerateActionsEnumCode();
                var actionsReaderCode = generator.GenerateInputActionsReaderCode();
                var messagesHandlerCode = generator.GenerateMessageHandlerCode();
                
                FileWriter.CreateAndWrite($"{selectedFolderPath}/{map.name}", $"{generator.BaseClassName}.cs", interfaceCode);     
                FileWriter.CreateAndWrite($"{selectedFolderPath}/{map.name}", $"{generator.EnumName}.cs", enumCode);
                FileWriter.CreateAndWrite($"{selectedFolderPath}/{map.name}", $"{generator.ActionsReaderClassName}.cs", actionsReaderCode);
                FileWriter.CreateAndWrite($"{selectedFolderPath}/{map.name}", $"{generator.MessagesHandlerClassName}.cs", messagesHandlerCode);
            }

            AssetDatabase.Refresh();
        }
    }
}