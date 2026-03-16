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
    /// 输入绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnInputAttribute : GameEngine.OnInputDispatchCallAttribute
    {
        public OnInputAttribute(int inputCode) : base(inputCode, GameEngine.AspectBehaviourType.Startup) { }

        public OnInputAttribute(int inputCode, GameEngine.InputOperationType inputOperationType) : base(inputCode, inputOperationType, GameEngine.AspectBehaviourType.Startup) { }

        public OnInputAttribute(Type inputDataType) : base(inputDataType, GameEngine.AspectBehaviourType.Startup) { }

        public OnInputAttribute(Type classType, int inputCode) : base(classType, inputCode) { }

        public OnInputAttribute(Type classType, int inputCode, GameEngine.InputOperationType inputOperationType) : base(classType, inputCode, inputOperationType) { }

        public OnInputAttribute(Type classType, Type inputDataType) : base(classType, inputDataType) { }
    }

    /// <summary>
    /// 事件绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnEventAttribute : GameEngine.OnEventDispatchCallAttribute
    {
        public OnEventAttribute(int eventID) : base(eventID, GameEngine.AspectBehaviourType.Startup) { }

        public OnEventAttribute(Type eventDataType) : base(eventDataType, GameEngine.AspectBehaviourType.Startup) { }

        public OnEventAttribute(Type classType, int eventID) : base(classType, eventID) { }

        public OnEventAttribute(Type classType, Type eventDataType) : base(classType, eventDataType) { }
    }

    /// <summary>
    /// 消息绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnMessageAttribute : GameEngine.OnMessageDispatchCallAttribute
    {
        public OnMessageAttribute(int opcode) : base(opcode, GameEngine.AspectBehaviourType.Startup) { }

        public OnMessageAttribute(Type messageType) : base(messageType, GameEngine.AspectBehaviourType.Startup) { }

        public OnMessageAttribute(Type classType, int opcode) : base(classType, opcode) { }

        public OnMessageAttribute(Type classType, Type messageType) : base(classType, messageType) { }
    }

    /// <summary>
    /// 同步绑定函数的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OnReplicateAttribute : GameEngine.OnReplicateDispatchCallAttribute
    {
        public OnReplicateAttribute(string tags) : base(tags, GameEngine.AspectBehaviourType.Startup) { }

        public OnReplicateAttribute(string tags, GameEngine.ReplicateAnnounceType announceType) : base(tags, announceType, GameEngine.AspectBehaviourType.Startup) { }

        public OnReplicateAttribute(Type classType, string tags) : base(classType, tags) { }

        public OnReplicateAttribute(Type classType, string tags, GameEngine.ReplicateAnnounceType announceType) : base(classType, tags, announceType) { }
    }
}
