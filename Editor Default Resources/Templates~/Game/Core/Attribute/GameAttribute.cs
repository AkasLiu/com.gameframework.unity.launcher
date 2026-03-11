/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-06-11
/// 功能描述：
/// </summary>

using System;

namespace Game
{
    /// <summary>
    /// 游戏业务模块特性定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GameAttribute : Attribute
    {
    }
}
