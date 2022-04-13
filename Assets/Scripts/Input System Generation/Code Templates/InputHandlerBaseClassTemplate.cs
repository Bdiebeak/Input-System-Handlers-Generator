using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Bdiebeak.InputSystemGeneration
{
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class InputHandlerBaseClassTemplate : TemplateGenerator
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            Write("using UnityEngine;");
            Write("\r\n\r\n");

            Write("/// <summary>\r\n");
            Write("/// This is an abstract class but not an interface because\r\n");
            Write("/// it gives us an opportunity to assign it from inspector.\r\n");
            Write("/// </summary>");
            Write("\r\n");
            
            Write("public abstract class ");
            Write(ToStringHelper.ToStringWithCulture(baseClassName));
            Write(" : MonoBehaviour\r\n");
            
            Write("{\r\n");

            foreach (var action in actions)
            {
                    Write("\tpublic ");
                    Write(ToStringHelper.ToStringWithCulture(action.Value));
                    
                    Write(" ");
                    Write(ToStringHelper.ToStringWithCulture(action.Key));
                    Write("Value");
                    
                    Write(" { get; protected set; }\r\n");
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
