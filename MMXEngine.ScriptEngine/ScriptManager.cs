using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using Artemis;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.ScriptMethods;
using NLua;
#pragma warning disable 1591

namespace MMXEngine.ScriptEngine
{
    public class ScriptManager : IScriptManager
    {
        private readonly Lua _luaEngine;
        private readonly Queue<ScriptQueueObject> _scriptQueue;
        private readonly IFileSystem _fileSystem;

        // Methods
        private readonly IAudioMethods _audioMethods;
        private readonly IEntityMethods _entityMethods;
        private readonly ILevelMethods _levelMethods;
        private readonly ILocalDataMethods _localDataMethods;
        private readonly IMiscellaneousMethods _miscellaneousMethods;
        private readonly IPhysicsMethods _physicsMethods;
        private readonly IPlayerMethods _playerMethods;
        private readonly ISpriteMethods _spriteMethods;

        public ScriptManager(
            IFileSystem fileSystem,
            IAudioMethods audioMethods,
            IEntityMethods entityMethods,
            ILevelMethods levelMethods,
            ILocalDataMethods localDataMethods,
            IMiscellaneousMethods miscellaneousMethods,
            IPhysicsMethods physicsMethods,
            IPlayerMethods playerMethods,
            ISpriteMethods spriteMethods)
        {
            _fileSystem = fileSystem;

            _audioMethods = audioMethods;
            _entityMethods = entityMethods;
            _levelMethods = levelMethods;
            _localDataMethods = localDataMethods;
            _miscellaneousMethods = miscellaneousMethods;
            _physicsMethods = physicsMethods;
            _playerMethods = playerMethods;
            _spriteMethods = spriteMethods;

            _scriptQueue = new Queue<ScriptQueueObject>();
            _luaEngine = new Lua();
            SandboxVM();
            RegisterEnumerations();
            RegisterMethods();
        }

        public void QueueScript(string fileName, Entity entity, string methodName = "Main")
        {
            fileName = _fileSystem.Path.GetDirectoryName(fileName) + "\\" +
                _fileSystem.Path.GetFileNameWithoutExtension(fileName) + ".lua";
            if (!_fileSystem.File.Exists(".\\Content\\Compiled\\Scripts\\" + fileName))
            {
                throw new FileNotFoundException("Script '" + fileName + "' could not be found.");
            }

            _scriptQueue.Enqueue(new ScriptQueueObject(fileName, methodName, entity));
        }

        public void ExecuteScripts()
        {
            while(_scriptQueue.Count > 0)
            {
                var script = _scriptQueue.Dequeue();
                _luaEngine["self"] = script.TargetObject;

                string text = _fileSystem.File.ReadAllText(".\\Content\\Compiled\\Scripts\\" + script.FilePath);
                _luaEngine.DoString(text);

                if (_luaEngine.GetFunction(script.MethodName) != null)
                {
                    try
                    {
                        ((LuaFunction)_luaEngine[script.MethodName]).Call();
                    }
                    catch (Exception)
                    {
                        string fileName = _fileSystem.Path.GetFileName(script.FilePath);
                        // TODO: Log script error
                        throw;
                    }
                }
            }
        }

        public IEnumerable<string> GetRegisteredMethods()
        {
            return _luaEngine.Globals;
        }

        public IEnumerable<string> GetRegisteredEnumerations()
        {
            List<string> enumerations = new List<string>();

            enumerations.AddRange(TableToEnumerationText("CharacterType"));
            enumerations.AddRange(TableToEnumerationText("CollisionType"));
            enumerations.AddRange(TableToEnumerationText("DirectionType"));
            enumerations.AddRange(TableToEnumerationText("GameButton"));
            enumerations.AddRange(TableToEnumerationText("Color"));

            enumerations.Sort();

            return enumerations;
        }

        private void SandboxVM()
        {
            _luaEngine.DoString("import = function() end");
        }

        private void RegisterEnumerations()
        {
            EnumerationToTable("CharacterType", typeof(CharacterType));
            EnumerationToTable("CollisionType", typeof(CollisionType));
            EnumerationToTable("DirectionType", typeof(Direction));
            EnumerationToTable("GameButton", typeof(GameButton));
            EnumerationToTable("Color", typeof(ColorType));
        }

        private void RegisterMethods()
        {
            _luaEngine[GetMethodNamespace(_audioMethods)] = _audioMethods;
            _luaEngine[GetMethodNamespace(_entityMethods)] = _entityMethods;
            _luaEngine[GetMethodNamespace(_levelMethods)] = _levelMethods;
            _luaEngine[GetMethodNamespace(_localDataMethods)] = _localDataMethods;
            _luaEngine[GetMethodNamespace(_miscellaneousMethods)] = _miscellaneousMethods;
            _luaEngine[GetMethodNamespace(_physicsMethods)] = _physicsMethods;
            _luaEngine[GetMethodNamespace(_playerMethods)] = _playerMethods;
            _luaEngine[GetMethodNamespace(_spriteMethods)] = _spriteMethods;
        }

        private static string GetMethodNamespace(object methodGroup)
        {
            return ((ScriptNamespaceAttribute)methodGroup.GetType().GetCustomAttribute(typeof(ScriptNamespaceAttribute))).Namespace;
        }

        private void EnumerationToTable(string luaTableName, Type enumType)
        {
            _luaEngine.NewTable(luaTableName);
            LuaTable lt = (LuaTable)_luaEngine[luaTableName];

            foreach (var val in Enum.GetValues(enumType))
            {
                lt[Enum.GetName(enumType, val)] = val;
            }
        }

        private List<string> TableToEnumerationText(string luaTableName)
        {
            LuaTable lt = _luaEngine.GetTable(luaTableName);
            List<string> values = new List<string>();

            foreach (var value in lt.Values)
            {
                values.Add(luaTableName + "." + value);
            }

            return values;
        }
    }
}
#pragma warning restore 1591