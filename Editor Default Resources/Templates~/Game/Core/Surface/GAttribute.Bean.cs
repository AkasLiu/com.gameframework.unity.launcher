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
    public class GObjectClassAttribute : GameEngine.CObjectClassAttribute
    {
        public GObjectClassAttribute() : base() { }

        public GObjectClassAttribute(string viewName) : base(viewName) { }

        public GObjectClassAttribute(int priority) : base(priority) { }

        public GObjectClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    /// <summary>
    /// 场景实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class GSceneClassAttribute : GameEngine.CSceneClassAttribute
    {
        public GSceneClassAttribute() : base() { }

        public GSceneClassAttribute(string viewName) : base(viewName) { }

        public GSceneClassAttribute(int priority) : base(priority) { }

        public GSceneClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    /// <summary>
    /// 角色实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class GActorClassAttribute : GameEngine.CActorClassAttribute
    {
        public GActorClassAttribute() : base() { }

        public GActorClassAttribute(string viewName) : base(viewName) { }

        public GActorClassAttribute(int priority) : base(priority) { }

        public GActorClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    /// <summary>
    /// 视图实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class GViewClassAttribute : GameEngine.CViewClassAttribute
    {
        public GViewClassAttribute() : base() { }

        public GViewClassAttribute(string viewName) : base(viewName) { }

        public GViewClassAttribute(int priority) : base(priority) { }

        public GViewClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    /// <summary>
    /// 组件实现类声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class GComponentClassAttribute : GameEngine.CComponentClassAttribute
    {
        public GComponentClassAttribute() : base() { }

        public GComponentClassAttribute(string viewName) : base(viewName) { }

        public GComponentClassAttribute(int priority) : base(priority) { }

        public GComponentClassAttribute(string viewName, int priority) : base(viewName, priority) { }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 视图分组策略声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class GViewGroupAttribute : GameEngine.CViewGroupAttribute
    {
        public GViewGroupAttribute(string groupName) : base(groupName) { }
    }

    /// <summary>
    /// 实体自动挂载的目标组件的属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class GComponentAutomaticActivationOfEntityAttribute : GameEngine.CComponentAutomaticActivationOfEntityAttribute
    {
        public GComponentAutomaticActivationOfEntityAttribute(Type referenceType) : base(referenceType) { }

        public GComponentAutomaticActivationOfEntityAttribute(Type referenceType, int priority) : base(referenceType, priority) { }

        public GComponentAutomaticActivationOfEntityAttribute(Type referenceType, int priority, GameEngine.AspectBehaviourType activationBehaviourType) : base(referenceType, priority, activationBehaviourType) { }
    }
}
