namespace MMXEngine.Windows.Editor.Objects
{
    public class FileOpenerData
    {
        public string Extension { get; set; }
        public string CategoryName { get; set; }
        public string CategorySingle { get; set; }
        public string RootDirectory { get; set; }
        public bool WatchDirectory { get; set; }
        public string OpenedFile { get; set; }
        public bool ShowNoneOption { get; set; }
        public bool UserSelectedNoneOption { get; set; }
        public bool WasActionCanceled { get; set; }

        public FileOpenerData()
        {
            Extension = string.Empty;
            CategoryName = string.Empty;
            CategorySingle = string.Empty;
            RootDirectory = string.Empty;
            WatchDirectory = true;
            OpenedFile = string.Empty;
            ShowNoneOption = false;
            UserSelectedNoneOption = false;
            WasActionCanceled = true;
        }

        public FileOpenerData(string extension, string categoryName, string categorySingle, string rootDirectory, bool watchDirectory, bool showNoneOption)
        {
            Extension = extension;
            CategoryName = categoryName;
            CategorySingle = categorySingle;
            RootDirectory = rootDirectory;
            WatchDirectory = watchDirectory;
            OpenedFile = string.Empty;
            ShowNoneOption = showNoneOption;
            UserSelectedNoneOption = false;
            WasActionCanceled = true;
        }

    }
}
