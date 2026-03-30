/// <summary>
/// 2025-12-10 Game Framework Code By Hurley
/// </summary>

using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Logo场景
    /// </summary>
    static class LogoSceneSystem
    {
        [OnAwake]
        static void Awake(this LogoScene self)
        {
        }

        [OnStart]
        static void Start(this LogoScene self)
        {
            Debug.Log("hello world");
        }

        [OnDestroy]
        static void Destroy(this LogoScene self)
        {
        }
    }
}
