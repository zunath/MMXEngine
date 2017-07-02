using System;
using MMXEngine.Windows.Editor.Objects;
using Prism.Events;

namespace MMXEngine.Windows.Editor.Events.Controls
{
    public class FileDirectoryTreeViewSelectedItemEvent: PubSubEvent<Tuple<string, PathItem>>
    {
    }
}
