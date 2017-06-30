using System.Collections.Generic;

namespace MMXEngine.Windows.Editor.Objects
{
    public class DirectoryItem: PathItem
    {
        public List<PathItem> Items { get; set; }

        public DirectoryItem()
        {
            Items = new List<PathItem>();
        }

    }
}
