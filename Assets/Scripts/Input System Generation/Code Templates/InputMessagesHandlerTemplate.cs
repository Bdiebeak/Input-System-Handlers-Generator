using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Bdiebeak.InputSystemGeneration
{
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class InputMessagesHandlerTemplate : TemplateGenerator
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            Write("using UnityEngine;\r\nusing UnityEngine.InputSystem;");
            Write("\r\n\r\n");
            Write("[RequireComponent(typeof(PlayerInput))]\r\n");
            Write("public class ");
            Write(ToStringHelper.ToStringWithCulture(className));
            Write(" : ");
            Write(ToStringHelper.ToStringWithCulture(baseClassName));
            Write("\r\n{");

            foreach (var action in actions)
            {
                Write("\r\n");
                Write("\tprivate void On");
                Write(ToStringHelper.ToStringWithCulture(action.Key));
                Write("(InputValue value)\r\n    {\r\n");
            
                Write("\t\t");
                Write(ToStringHelper.ToStringWithCulture(action.Key));
                Write("Value");
                
                if (action.Value == "bool")
                {
                    Write(" = value.isPressed;\r\n");
                }
                else
                {
                    Write(" = value.Get<");
                    Write(ToStringHelper.ToStringWithCulture(action.Value));
                    Write(">();\r\n");
                }
                
                Write("\t}\r\n");
            }
            
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
