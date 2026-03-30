using ProtoBuf;
using ProtoBuf.Extension;
using System.Collections.Generic;

namespace Game.Proto
{
    /// <summary>
    /// 进入游戏
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.EnterWorldReq)]
    [MessageResponseType(ProtoOpcode.EnterWorldResp)]
    public partial class EnterWorldReq : Object, IMessage
    {
        [ProtoMember(1)]
        public int Uid { get; set; }
    }

    /// <summary>
    /// 进入游戏回复
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.EnterWorldResp)]
    public partial class EnterWorldResp : Object, IMessage
    {
        [ProtoMember(1)]
        public int Code { get; set; }

        [ProtoMember(2)]
        public MapInfo Map { get; set; }

        [ProtoMember(3)]
        public PlayerInfo Player { get; set; }
    }

    [ProtoContract]
    [Message(ProtoOpcode.ExitWorldReq)]
    [MessageResponseType(ProtoOpcode.ExitWorldResp)]
    public partial class ExitWorldReq : Object, IMessage
    {
    }

    [ProtoContract]
    [Message(ProtoOpcode.ExitWorldResp)]
    public partial class ExitWorldResp : Object, IMessage
    {
    }

    /// <summary>
    /// 地图信息
    /// </summary>
    [ProtoContract]
    public partial class MapInfo : Object
    {
        [ProtoMember(1)]
        public int Uid { get; set; }
    }

    /// <summary>
    /// 玩家信息
    /// </summary>
    [ProtoContract]
    public partial class PlayerInfo : Object
    {
        [ProtoMember(1)]
        public SoldierInfo Soldier { get; set; }
    }

    /// <summary>
    /// 怪物信息
    /// </summary>
    [ProtoContract]
    public partial class MonsterInfo : Object
    {
        [ProtoMember(1)]
        public SoldierInfo Soldier { get; set; }
    }

    /// <summary>
    /// 玩家信息同步
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.PlayerInfoSyncNotify)]
    public partial class PlayerInfoSyncNotify : Object, IMessage
    {
        [ProtoMember(1)]
        public PlayerInfo Player { get; set; }
    }

    /// <summary>
    /// 玩家经验变动
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.PlayerExpChangedNotify)]
    public partial class PlayerExpChangedNotify : Object, IMessage
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
    }

    /// <summary>
    /// 区域对象生成
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.AreaSpawnNotify)]
    public partial class AreaSpawnNotify : Object, IMessage
    {
        [ProtoMember(1)]
        public List<MonsterInfo> MonsterList { get; set; }
    }
}
