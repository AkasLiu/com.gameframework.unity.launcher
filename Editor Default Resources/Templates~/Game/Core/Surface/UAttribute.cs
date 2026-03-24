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
    /// 全局编程接口分发类型注册函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OnGlobalApiAttribute : GameEngine.OnApiDispatchCallAttribute
    {
        public OnGlobalApiAttribute(string functionName) : base(functionName) { }

        public OnGlobalApiAttribute(Type classType, string functionName) : base(classType, functionName) { }
    }

    /// <summary>
    /// 对象编程接口分发类型注册函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OnBeanApiAttribute : GameEngine.ApiFunctionBindingOfTargetAttribute
    {
        public OnBeanApiAttribute(string functionName) : base(functionName) { }
    }
}
