/// <summary>
/// 2023-08-29 Game Framework Code By Hurley
/// </summary>

using System.Collections.Generic;

namespace Game
{
    public static class AssemblyLoader
    {
        public static void Load()
        {
            LoadAllAssemblies();
        }

        public static void Unload()
        {
        }

        public static void Reload()
        {
            LoadAllAssemblies(true);
        }

        /// <summary>
        /// 加载所有程序集
        /// </summary>
        private static void LoadAllAssemblies(bool reload = false)
        {
            IReadOnlyList<string> assemblyNames = NovaEngine.Configuration.GetAllCompilableAssemblyNames();

            for (int n = 0; n < assemblyNames.Count; ++n)
            {
                // System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(assemblyNames[n]);
                // System.Reflection.Assembly assembly = AppEngine.AppStart.GetLoadedAssembly(assemblyNames[n]);
                System.Reflection.Assembly assembly = NovaEngine.Utility.Assembly.GetAssembly(assemblyNames[n]);
                if (null == assembly)
                {
                    Debugger.Error("Could not found any assembly from target name '{%s}'.", assemblyNames[n]);
                    continue;
                }

                GameEngine.GameLibrary.LoadFromAssembly(assembly, reload);
            }
        }
    }
}
