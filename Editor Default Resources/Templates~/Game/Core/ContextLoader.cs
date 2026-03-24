using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// 上下文加载器管理类
    /// </summary>
    public static class ContextLoader
    {
        public static async UniTask Load()
        {
            await LoadApplicationConfigures();
            // LoadBeanConfigures();
        }

        public static void Unload()
        {
        }

        public static async UniTask Reload()
        {
            await UniTask.WaitForSeconds(1);
        }

        private static async UniTask LoadApplicationConfigures()
        {
            await GameEngine.ApplicationContext.LoadApplicationConfigure(@"application", async (path, ms) =>
            {
                string filePath = NovaEngine.Environment.GetSystemPath("CONTEXT_PATH"); // , $"{path}.xml");
                if (string.IsNullOrEmpty(filePath))
                {
                    Debugger.Warn("当前程序启动环境中无法找到“CONTEXT_PATH”的资源路径配置信息，加载配置数据失败！");
                    return false;
                }

                string url = $"{filePath}/{path}.xml";
                Debugger.Log("加载配置{%s}", url);
                // UnityEngine.TextAsset textAsset = GameEngine.ResourceHandler.Instance.LoadAsset($"{filePath}/{path}.xml", typeof(UnityEngine.TextAsset)) as UnityEngine.TextAsset;
                // UnityEngine.TextAsset textAsset = GameEngine.ResourceHandler.Instance.LoadAsset(url, typeof(UnityEngine.TextAsset)) as UnityEngine.TextAsset;
                UnityEngine.TextAsset textAsset = await GameEngine.ResourceHandler.Instance.AsyncLoadAsset<UnityEngine.TextAsset>(url);
                string text = textAsset.text;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
                ms.Write(buffer, 0, buffer.Length);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                GameEngine.ResourceHandler.Instance.UnloadAsset(textAsset);

                return true;
            });
        }

        private static void LoadBeanConfigures()
        {
            GameEngine.ApplicationContext.LoadBeanConfigure(@"bean", (path, ms) =>
            {
                string filePath = NovaEngine.Environment.GetSystemPath("CONTEXT_PATH"); // , $"{path}.xml");
                if (string.IsNullOrEmpty(filePath))
                {
                    Debugger.Warn("当前程序启动环境中无法找到“CONTEXT_PATH”的资源路径配置信息，加载配置数据失败！");
                    return false;
                }

                UnityEngine.TextAsset textAsset = GameEngine.ResourceHandler.Instance.LoadAsset($"{filePath}/{path}.xml", typeof(UnityEngine.TextAsset)) as UnityEngine.TextAsset;
                string text = textAsset.text;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
                ms.Write(buffer, 0, buffer.Length);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                GameEngine.ResourceHandler.Instance.UnloadAsset(textAsset);

                return true;
            });
        }
    }
}
