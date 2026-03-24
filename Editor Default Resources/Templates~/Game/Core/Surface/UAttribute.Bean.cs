/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-12-06
/// 功能描述：
/// </summary>

using System;

namespace Game
{
    /// <summary>
    /// 对象实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UObjectClassAttribute : GameEngine.CObjectClassAttribute
    {
        public UObjectClassAttribute() : base() { }

        public UObjectClassAttribute(string viewName) : base(viewName) { }

        public UObjectClassAttribute(int priority) : base(priority) { }

        public UObjectClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    /// <summary>
    /// 场景实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class USceneClassAttribute : GameEngine.CSceneClassAttribute
    {
        public USceneClassAttribute() : base() { }

        public USceneClassAttribute(string viewName) : base(viewName) { }

        public USceneClassAttribute(int priority) : base(priority) { }

        public USceneClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    /// <summary>
    /// 角色实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UActorClassAttribute : GameEngine.CActorClassAttribute
    {
        public UActorClassAttribute() : base() { }

        public UActorClassAttribute(string viewName) : base(viewName) { }

        public UActorClassAttribute(int priority) : base(priority) { }

        public UActorClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    /// <summary>
    /// 视图实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UViewClassAttribute : GameEngine.CViewClassAttribute
    {
        public UViewClassAttribute() : base() { }

        public UViewClassAttribute(string viewName) : base(viewName) { }

        public UViewClassAttribute(int priority) : base(priority) { }

        public UViewClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    /// <summary>
    /// 组件实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UComponentClassAttribute : GameEngine.CComponentClassAttribute
    {
        public UComponentClassAttribute() : base() { }

        public UComponentClassAttribute(string viewName) : base(viewName) { }

        public UComponentClassAttribute(int priority) : base(priority) { }

        public UComponentClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 视图分组策略声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UViewGroupAttribute : GameEngine.CViewGroupAttribute
    {
        public UViewGroupAttribute(string groupName) : base(groupName) { }
    }

    /// <summary>
    /// 实体自动挂载的目标组件的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class UComponentAutomaticActivationOfEntityAttribute : GameEngine.CComponentAutomaticActivationOfEntityAttribute
    {
        public UComponentAutomaticActivationOfEntityAttribute(Type referenceType) : base(referenceType) { }

        public UComponentAutomaticActivationOfEntityAttribute(Type referenceType, int priority) : base(referenceType, priority) { }

        public UComponentAutomaticActivationOfEntityAttribute(Type referenceType, int priority, GameEngine.AspectBehaviourType activationBehaviourType) : base(referenceType, priority, activationBehaviourType) { }
    }
}
