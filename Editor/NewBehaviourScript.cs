using System.Collections;
using System.Collections.Generic;
using NovaFramework.Editor.Preference;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript
{
    [MenuItem("Tools/xxxxx")]
    public static void ValidateEnvironment()
    {
        Debug.Log("验证环境");
        
        LauncherInstallationStep launcherInstallationStep = new LauncherInstallationStep();
        launcherInstallationStep.Install();
    }
}
