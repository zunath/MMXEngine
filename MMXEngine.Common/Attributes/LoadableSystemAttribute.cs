using System;

namespace MMXEngine.Common.Attributes
{
    public class LoadableSystemAttribute: Attribute
    {
        public int LoadOrder { get; set; }

        public LoadableSystemAttribute(int loadOrder)
        {
            LoadOrder = loadOrder;
        }
    }
}
