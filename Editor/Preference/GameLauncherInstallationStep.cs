

using System;
using System.IO;
using System.Linq;
using NovaFramework.Serialization;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NovaFramework.Editor.Preference
{
    public class GameLauncherInstallationStep : InstallationStep
    {
        public void Install(Action onComplete, Action onError)
        {
            try
            {
                Debug.Log("LauncherInstallationStep: 开始执行安装步骤");

                //1.拷贝Templates~文件夹代码到Sources目录
                string moduleName = "com.gameframework.unity.launcher";
                string curModulePath = PersistencePath.FindModuleFolderByPackageName(moduleName);
                string curTemplatesDirPath = Application.dataPath + "/../" + curModulePath + "/Editor Default Resources/Templates~";
                string curGUIDirPath = Application.dataPath + "/../" + curModulePath + "/Editor Default Resources/GUI";
                string sourcesPath = Path.Combine(Application.dataPath, "..", "Assets/Sources").Replace("\\", "/");
                string _ResourcesPath = Path.Combine(Application.dataPath, "..", "Assets/_Resources/GUI").Replace("\\", "/");

                //拷贝Templates~文件夹到Assets/Sources
                if (Directory.Exists(curTemplatesDirPath))
                {
                    DirectoryCopy(curTemplatesDirPath, sourcesPath);
                    Debug.Log("已拷贝模板代码到 Assets/Sources");
                }
                else
                {
                    Debug.Log($"Templates~ 目录不存在: {curTemplatesDirPath}");
                }
                
                //2. 创建主场景到Scenes目录
                string scenesDir = Path.Combine(Application.dataPath, "Scenes");
                if (!Directory.Exists(scenesDir))
                {
                    Directory.CreateDirectory(scenesDir);
                }
                
                string destScenePath = Path.Combine(scenesDir, "main.unity");
                
                // 使用Unity API创建一个新的空场景
                Scene newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
                
                // 保存新创建的场景到目标路径
                EditorSceneManager.SaveScene(newScene, destScenePath);
                Debug.Log("已创建主场景 Assets/Scenes/main.unity");
                
                //3. 复制DLL到AOT/Windows目录
                string sourceAotPath = Path.Combine(curModulePath, "Editor Default Resources/Aot/Windows").Replace("\\", "/");
                if (Directory.Exists(sourceAotPath))
                {
                    string aotDestPath = "Assets/_Resources/Aot/Windows";
                    var aotPathVar = EnvironmentConfigures.Instance.variables.FirstOrDefault(v => v.key == "AOT_LIBRARY_PATH");
                    if (aotPathVar != null && !string.IsNullOrEmpty(aotPathVar.value))
                    {
                        aotDestPath = Path.Combine(aotPathVar.value, "Windows").Replace("\\", "/");
                    }
                
                    string aotAbsPath = Path.Combine(Application.dataPath, "..", aotDestPath).Replace("\\", "/");
                    DirectoryCopy(sourceAotPath, aotAbsPath);
                
                    string[] dllFiles = Directory.GetFiles(sourceAotPath, "*.dll.bytes");
                    Debug.Log($"已复制 {dllFiles.Length} 个AOT库文件到 {aotDestPath}");
                }
                else
                {
                    Debug.Log($"AOT源目录不存在，跳过DLL复制: {sourceAotPath}");
                }

                // 4.复制默认资源
                if (Directory.Exists(curGUIDirPath))
                {
                    DirectoryCopy(curGUIDirPath, _ResourcesPath);
                    Debug.Log("已拷贝GUI到 Assets/_Resources/GUI");
                }
                else
                {
                    Debug.Log($"GUI 目录不存在: {curGUIDirPath}");
                }
                
                AssetDatabase.Refresh();
                
                onComplete?.Invoke();
            }
            catch (Exception e)
            {
                onError?.Invoke();
                Debug.Log($"安装过程中发生错误: {e.Message}");
            }
        }

        private void DirectoryCopy(string srcDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            foreach (string file in Directory.GetFiles(srcDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (string subDir in Directory.GetDirectories(srcDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
                DirectoryCopy(subDir, destSubDir);
            }
        }
        
        public void Uninstall(Action onComplete, Action onError)
        {
            Debug.Log("LauncherInstallationStep: 执行卸载步骤");

            // 1. 删除 Assets/Sources
            // string sourcesPath = Path.Combine(Application.dataPath, "Sources");
            // if (Directory.Exists(sourcesPath))
            // {
            //     Directory.Delete(sourcesPath, true);
            //     DeleteMetaFile(sourcesPath);
            // }
            //
            // // 2. 删除 Assets/Scenes/main.unity
            // string scenePath = Path.Combine(Application.dataPath, "Scenes", "main.unity");
            // if (File.Exists(scenePath))
            // {
            //     File.Delete(scenePath);
            //     DeleteMetaFile(scenePath);
            // }
            //
            // // 3. 删除 Assets/_Resources/GUI
            // string guiPath = Path.Combine(Application.dataPath, "_Resources", "GUI");
            // if (Directory.Exists(guiPath))
            // {
            //     Directory.Delete(guiPath, true);
            //     DeleteMetaFile(guiPath);
            // }

            AssetDatabase.Refresh();

            onComplete?.Invoke();
        }

        private static void DeleteMetaFile(string path)
        {
            string metaFile = path + ".meta";
            if (File.Exists(metaFile))
            {
                File.Delete(metaFile);
            }
        }
        
    }
}
