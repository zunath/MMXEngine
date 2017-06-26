using System;

namespace MMXEngine.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ScriptNamespaceAttribute: Attribute
    {
        public string Namespace { get; set; }

        public ScriptNamespaceAttribute(string @namespace)
        {
            Namespace = @namespace;
        }
    }
}
