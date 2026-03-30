using ProtoBuf;
using ProtoBuf.Extension;
using System.Collections.Generic;

namespace Game.Proto
{
    /// <summary>
    /// 二维向量信息
    /// </summary>
    [ProtoContract]
    public partial class Vector2Info : Object
    {
        [ProtoMember(1)]
        public float x { get; set; }

        [ProtoMember(2)]
        public float y { get; set; }
    }

    /// <summary>
    /// 三维向量信息
    /// </summary>
    [ProtoContract]
    public partial class Vector3Info : Object
    {
        [ProtoMember(1)]
        public float x { get; set; }

        [ProtoMember(2)]
        public float y { get; set; }

        [ProtoMember(3)]
        public float z { get; set; }
    }

    /// <summary>
    /// 基础信息
    /// </summary>
    [ProtoContract]
    public partial class BaseInfo : Object
    {
        [ProtoMember(1)]
        public int Uid { get; set; }

        /// <summary>
        /// 引用
        /// </summary>
        [ProtoMember(2)]
        public int ClassId { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [ProtoMember(3)]
        public string Name { get; set; }
    }

    /// <summary>
    /// 主状态信息
    /// </summary>
    [ProtoContract]
    public partial class MainStatInfo : Object
    {
        /// <summary>
        /// 等级
        /// </summary>
        [ProtoMember(1)]
        public int Level { get; set; }

        /// <summary>
        /// 经验
        /// </summary>
        [ProtoMember(2)]
        public int Exp { get; set; }

        /// <summary>
        /// 生命
        /// </summary>
        [ProtoMember(3)]
        public int Health { get; set; }

        /// <summary>
        /// 体力
        /// </summary>
        [ProtoMember(4)]
        public int Energy { get; set; }
    }

    /// <summary>
    /// 技能信息
    /// </summary>
    [ProtoContract]
    public partial class SkillInfo : Object
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [ProtoMember(2)]
        public int Level { get; set; }
    }

    /// <summary>
    /// 士兵信息
    /// </summary>
    [ProtoContract]
    public partial class SoldierInfo : Object
    {
        [ProtoMember(1)]
        public BaseInfo Basic { get; set; }

        /// <summary>
        /// 属性状态
        /// </summary>
        [ProtoMember(2)]
        public MainStatInfo MainStat { get; set; }

        /// <summary>
        /// 技能列表
        /// </summary>
        [ProtoMember(3)]
        public List<SkillInfo> SkillList { get; set; } = new();

        /// <summary>
        /// 位置
        /// </summary>
        [ProtoMember(4)]
        public Vector2Info Position { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        [ProtoMember(5)]
        public Vector2Info Direction { get; set; }
    }
}