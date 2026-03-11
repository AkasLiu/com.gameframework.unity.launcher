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
    /// 全局输入绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnGlobalInputAttribute : GameEngine.OnInputDispatchCallAttribute
    {
        public OnGlobalInputAttribute(int inputCode) : base(inputCode) { }

        public OnGlobalInputAttribute(int inputCode, GameEngine.InputOperationType inputOperationType) : base(inputCode, inputOperationType) { }

        public OnGlobalInputAttribute(Type inputDataType) : base(inputDataType) { }

        public OnGlobalInputAttribute(Type classType, int inputCode) : base(classType, inputCode) { }

        public OnGlobalInputAttribute(Type classType, int inputCode, GameEngine.InputOperationType inputOperationType) : base(classType, inputCode, inputOperationType) { }

        public OnGlobalInputAttribute(Type classType, Type inputDataType) : base(classType, inputDataType) { }
    }

    /// <summary>
    /// 对象输入绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnBeanInputAttribute : GameEngine.InputResponseBindingOfTargetAttribute
    {
        public OnBeanInputAttribute(int inputCode) : base(inputCode, GameEngine.AspectBehaviourType.Startup) { }

        public OnBeanInputAttribute(int inputCode, GameEngine.InputOperationType inputOperationType) : base(inputCode, inputOperationType, GameEngine.AspectBehaviourType.Startup) { }

        public OnBeanInputAttribute(Type inputDataType) : base(inputDataType, GameEngine.AspectBehaviourType.Startup) { }
    }

    /// <summary>
    /// 全局事件绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnGlobalEventAttribute : GameEngine.OnEventDispatchCallAttribute
    {
        public OnGlobalEventAttribute(int eventID) : base(eventID) { }

        public OnGlobalEventAttribute(Type eventDataType) : base(eventDataType) { }

        public OnGlobalEventAttribute(Type classType, int eventID) : base(classType, eventID) { }

        public OnGlobalEventAttribute(Type classType, Type eventDataType) : base(classType, eventDataType) { }
    }

    /// <summary>
    /// 对象事件绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnBeanEventAttribute : GameEngine.EventSubscribeBindingOfTargetAttribute
    {
        public OnBeanEventAttribute(int eventID) : base(eventID, GameEngine.AspectBehaviourType.Startup) { }

        public OnBeanEventAttribute(Type eventDataType) : base(eventDataType, GameEngine.AspectBehaviourType.Startup) { }
    }

    /// <summary>
    /// 全局消息绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnGlobalMessageAttribute : GameEngine.OnMessageDispatchCallAttribute
    {
        public OnGlobalMessageAttribute(int opcode) : base(opcode) { }

        public OnGlobalMessageAttribute(Type messageType) : base(messageType) { }

        public OnGlobalMessageAttribute(Type classType, int opcode) : base(classType, opcode) { }

        public OnGlobalMessageAttribute(Type classType, Type messageType) : base(classType, messageType) { }
    }

    /// <summary>
    /// 对象消息绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnBeanMessageAttribute : GameEngine.MessageListenerBindingOfTargetAttribute
    {
        public OnBeanMessageAttribute(int opcode) : base(opcode, GameEngine.AspectBehaviourType.Startup) { }

        public OnBeanMessageAttribute(Type messageType) : base(messageType, GameEngine.AspectBehaviourType.Startup) { }
    }
}
