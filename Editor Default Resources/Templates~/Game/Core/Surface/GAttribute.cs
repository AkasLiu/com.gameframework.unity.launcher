/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2024-05-10
/// 功能描述：
/// </summary>

using System;

namespace Game
{
    /// <summary>
    /// 编程接口分发类型注册函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OnApiFunctionAttribute : GameEngine.OnApiDispatchCallAttribute
    {
        public OnApiFunctionAttribute(string functionName) : base(functionName) { }

        public OnApiFunctionAttribute(Type classType, string functionName) : base(classType, functionName) { }
    }
}
