﻿using System.IO.Abstractions;
using MMXEngine.Contracts.Managers;
using Newtonsoft.Json;

namespace MMXEngine.Windows.Shared.Managers
{
    public class DataManager : IDataManager
    {
        private readonly IFileSystem _fileSystem;
        private const string RootDirectory = ".\\Content\\Data\\";

        public DataManager(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public T Load<T>(string fileName)
        {
            if (!_fileSystem.Directory.Exists(RootDirectory))
            {
                _fileSystem.Directory.CreateDirectory(RootDirectory);
            }

            string path = RootDirectory + fileName;
            return JsonConvert.DeserializeObject<T>(_fileSystem.File.ReadAllText(path));
        }

        public void Save(string fileName, object data, bool createDirectory = false)
        {
            string path = RootDirectory + fileName;
            string json = JsonConvert.SerializeObject(data);

            if (!_fileSystem.Directory.Exists(RootDirectory))
            {
                _fileSystem.Directory.CreateDirectory(RootDirectory);
            }

            if (createDirectory)
            {
                if (!_fileSystem.Directory.Exists(_fileSystem.Path.GetDirectoryName(path)))
                {
                    _fileSystem.Directory.CreateDirectory(_fileSystem.Path.GetDirectoryName(path));
                }
            }

            _fileSystem.File.WriteAllText(path, json);
        }
    }
}
