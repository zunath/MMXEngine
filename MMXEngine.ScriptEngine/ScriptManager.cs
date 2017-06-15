using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.ScriptMethods;
using NLua;

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
            if (!_fileSystem.File.Exists(".\\Scripts\\" + fileName))
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

                string text = _fileSystem.File.ReadAllText(".\\Scripts\\" + script.FilePath);
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
            _luaEngine["Audio"] = _audioMethods;
            _luaEngine["Entity"] = _entityMethods;
            _luaEngine["Level"] = _levelMethods;
            _luaEngine["LocalData"] = _localDataMethods;
            _luaEngine["Misc"] = _miscellaneousMethods;
            _luaEngine["Physics"] = _physicsMethods;
            _luaEngine["Player"] = _playerMethods;
            _luaEngine["Sprite"] = _spriteMethods;
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
    }
}
