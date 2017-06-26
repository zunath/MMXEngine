namespace MMXEngine.Windows.Editor.Objects
{
    public class FileSaverData
    {
        public string Extension { get; set; }
        public string CategoryName { get; set; }
        public string CategorySingle { get; set; }
        public string RootDirectory { get; set; }
        public bool WatchDirectory { get; set; }
        public string SavedFile { get; set; }
        public bool WasActionCanceled { get; set; }

        public FileSaverData()
        {
            Extension = string.Empty;
            CategoryName = string.Empty;
            CategorySingle = string.Empty;
            RootDirectory = string.Empty;
            WatchDirectory = true;
            WasActionCanceled = true;
        }

        public FileSaverData(string extension, string categoryName, string categorySingle, string rootDirectory, bool watchDirectory)
        {
            Extension = extension;
            CategoryName = categoryName;
            CategorySingle = categorySingle;
            RootDirectory = rootDirectory;
            WatchDirectory = watchDirectory;
            WasActionCanceled = true;
        }
    }
}
