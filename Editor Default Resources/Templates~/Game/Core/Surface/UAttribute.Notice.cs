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
    /// 视图窗口恢复通知声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UViewResumeAttribute : GameEngine.CViewNoticeCallAttribute
    {
        public UViewResumeAttribute() : base(GameEngine.ViewNoticeType.Resume) { }
    }

    /// <summary>
    /// 视图窗口暂停通知声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UViewPauseAttribute : GameEngine.CViewNoticeCallAttribute
    {
        public UViewPauseAttribute() : base(GameEngine.ViewNoticeType.Pause) { }
    }

    /// <summary>
    /// 视图窗口置顶通知声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UViewRevealAttribute : GameEngine.CViewNoticeCallAttribute
    {
        public UViewRevealAttribute() : base(GameEngine.ViewNoticeType.Reveal) { }
    }

    /// <summary>
    /// 视图窗口遮挡通知声明属性类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UViewCoverAttribute : GameEngine.CViewNoticeCallAttribute
    {
        public UViewCoverAttribute() : base(GameEngine.ViewNoticeType.Cover) { }
    }
}
