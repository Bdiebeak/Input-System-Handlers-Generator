using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Bdiebeak.InputSystemGeneration
{
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class InputActionsEnumTemplate : TemplateGenerator
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            Write("public enum ");
            Write(ToStringHelper.ToStringWithCulture(enumName));
            Write("\r\n{\r\n");

            foreach (var action in actions)
            {
                Write("\t");
                Write(ToStringHelper.ToStringWithCulture(action));
                Write(",\r\n");
            }
    
            Write("}\r\n");
            return GenerationEnvironment.ToString();
        }
        
        private string _enumNameField;
        
        /// <summary>
        /// Access the baseClassName parameter of the template.
        /// </summary>
        private string enumName
        {
            get
            {
                return _enumNameField;
            }
        }
        
        private List<string> _actionsField;
        
        /// <summary>
        /// Access the actions parameter of the template.
        /// </summary>
        private List<string> actions
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
                if (Session.ContainsKey("enumName"))
                {
                    _enumNameField = (string)Session["enumName"];
                    baseClassNameValueAcquired = true;
                }
                if (baseClassNameValueAcquired == false)
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
                    _actionsField = (List<string>)Session["actions"];
                    actionsValueAcquired = true;
                }
                if (actionsValueAcquired == false)
                {
                    var data = CallContext.LogicalGetData("actions");
                    if (data != null)
                    {
                        _actionsField = (List<string>)data;
                    }
                }
            }
        }
    }
}
