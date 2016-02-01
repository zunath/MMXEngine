using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Artemis;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Managers;
using MMXEngine.Interfaces.Systems;
using NLua;

namespace MMXEngine.ScriptEngine
{
    public class ScriptManager : IScriptManager
    {
        private readonly EntityWorld _world;
        private readonly Lua _lua;
        private readonly Queue<Tuple<string, IGameEntity>> _scriptQueue; 

        public ScriptManager(EntityWorld world)
        {
            _scriptQueue = new Queue<Tuple<string, IGameEntity>>();
            _world = world;
            _lua = new Lua();
            SandboxVM();
            RegisterScriptMethods();
        }

        public void QueueScript(string fileName, IGameEntity entity)
        {
            if (!File.Exists("./Scripts/" + fileName))
            {
                throw new Exception("Script '" + fileName + "' could not be found.");
            }

            _scriptQueue.Enqueue(new Tuple<string, IGameEntity>(fileName, entity));
        }

        public void ExecuteScripts()
        {
            while(_scriptQueue.Count > 0)
            {
                var script = _scriptQueue.Dequeue();
                _lua["this"] = script.Item2;
                _lua.DoFile("./Scripts/" + script.Item1);
                LuaFunction function = (LuaFunction)_lua["Main"];
                function.Call();
            }
        }

        private void SandboxVM()
        {
            _lua.DoString("import = function() end");
        }

        private void EnumerationToTable()
        {
            
        }

        private void RegisterScriptMethods()
        {
            var methods = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(p => typeof(IScriptMethodGroup).IsAssignableFrom(p))
                .SelectMany(m => m.GetMethods())
                .ToList();
            
            foreach (MethodInfo method in methods)
            {
                _lua.RegisterFunction(method.Name, method);
            }
        }
    }
}
