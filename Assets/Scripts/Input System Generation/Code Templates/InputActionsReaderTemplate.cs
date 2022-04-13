﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Bdiebeak.InputSystemGeneration
{
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class InputActionsReaderTemplate : TemplateGenerator
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            Write("using System;\r\n");
            Write("using System.Collections.Generic;\r\n");
            Write("using UnityEngine;\r\n");
            Write("using UnityEngine.InputSystem;\r\n");
            Write("\r\n");
            
            Write("[RequireComponent(typeof(PlayerInput))]\r\n");
            Write("public class ");
            Write(ToStringHelper.ToStringWithCulture(className));
            Write(" : ");
            Write(ToStringHelper.ToStringWithCulture(baseClassName));
            Write("\r\n{\r\n");
        
            Write("\tprivate PlayerInput _playerInput;\r\n");
            Write("\tprivate Dictionary<");
            Write(ToStringHelper.ToStringWithCulture(enumName));
            Write(", InputAction> _inputActions;\r\n\r\n");

            Write("\tprivate void Update()\r\n");
            Write("\t{\r\n");
            Write("\t\t// This initialization is handled in Update because Unity Input System's documentation says do it.\r\n");
            Write("\t\t// https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/api/UnityEngine.InputSystem.PlayerInput.html\r\n");
            Write("\t\tif (_playerInput == null || _inputActions == null) Reinitialize();\r\n");
            Write("\t\tHandleInput();\r\n");
            Write("\t}\r\n\r\n");

            Write("\tprivate void Reinitialize()\r\n");
            Write("\t{\r\n");
            Write("\t\t_playerInput = GetComponent<PlayerInput>();\r\n");
            Write($"\t\t_inputActions = new Dictionary<{ToStringHelper.ToStringWithCulture(enumName)}, InputAction>();\r\n");
            Write($"\t\tforeach (var actionValue in ({ToStringHelper.ToStringWithCulture(enumName)}[]) Enum.GetValues(typeof({ToStringHelper.ToStringWithCulture(enumName)})))\r\n");
            Write("\t\t\t_inputActions.Add(actionValue, _playerInput.actions[actionValue.ToString()]);\r\n");
            Write("\t}\r\n\r\n");
            
            Write("\tprivate void HandleInput()\r\n");
            Write("\t{\r\n");
            
            foreach (var action in actions)
            {
                Write("\t\t");
                Write(ToStringHelper.ToStringWithCulture(action.Key));
                Write("Value");
                Write($" = _inputActions[{ToStringHelper.ToStringWithCulture(enumName)}.{ToStringHelper.ToStringWithCulture(action.Key)}].");

                if (action.Value == "bool")
                {
                    Write("triggered;");
                    Write("// You can use any input which you need (e.g. inProgress, wasPressedThisFrame and etc.)");
                    Write("\r\n");
                }
                else
                {
                    Write("ReadValue<");
                    Write(ToStringHelper.ToStringWithCulture(action.Value));
                    Write(">();\r\n");
                }
            }
            
            Write("\t}\r\n");
            Write("}\r\n");
            return GenerationEnvironment.ToString();
        }
        
        private string _baseClassNameField;
        
        /// <summary>
        /// Access the baseClassName parameter of the template.
        /// </summary>
        private string baseClassName
        {
            get
            {
                return _baseClassNameField;
            }
        }
        
        private string _classNameField;
        
        /// <summary>
        /// Access the className parameter of the template.
        /// </summary>
        private string className
        {
            get
            {
                return _classNameField;
            }
        }
        
        private string _enumNameField;
        
        /// <summary>
        /// Access the className parameter of the template.
        /// </summary>
        private string enumName
        {
            get
            {
                return _enumNameField;
            }
        }
        
        private Dictionary<string, string> _actionsField;
        
        /// <summary>
        /// Access the actions parameter of the template.
        /// </summary>
        private Dictionary<string, string> actions
        {
            get
            {
                return _actionsField;
            }
        }

        /// <summary>
        /// Initialize the template
        /// </summary>
        public virtual void Initialize()
        {
            if (Errors.HasErrors == false)
            {
                var baseClassNameValueAcquired = false;
                if (Session.ContainsKey("baseClassName"))
                {
                    _baseClassNameField = (string)Session["baseClassName"];
                    baseClassNameValueAcquired = true;
                }
                if (baseClassNameValueAcquired == false)
                {
                    var data = CallContext.LogicalGetData("baseClassName");
                    if (data != null)
                    {
                        _baseClassNameField = (string)data;
                    }
                }
                
                var classNameValueAcquired = false;
                if (Session.ContainsKey("className"))
                {
                    _classNameField = (string)Session["className"];
                    classNameValueAcquired = true;
                }
                if (classNameValueAcquired == false)
                {
                    var data = CallContext.LogicalGetData("className");
                    if (data != null)
                    {
                        _classNameField = (string)data;
                    }
                }
                
                var enumNameValueAcquired = false;
                if (Session.ContainsKey("enumName"))
                {
                    _enumNameField = (string)Session["enumName"];
                    enumNameValueAcquired = true;
                }
                if (enumNameValueAcquired == false)
                {
                    var data = CallContext.LogicalGetData("enumName");
                    if (data != null)
                    {
                        _enumNameField = (string)data;
                    }
                }

                var actionsValueAcquired = false;
                if (Session.ContainsKey("actions"))
                {
                    _actionsField = (Dictionary<string, string>)Session["actions"];
                    actionsValueAcquired = true;
                }
                if (actionsValueAcquired == false)
                {
                    var data = CallContext.LogicalGetData("actions");
                    if (data != null)
                    {
                        _actionsField = (Dictionary<string, string>)data;
                    }
                }
            }
        }
    }
}
