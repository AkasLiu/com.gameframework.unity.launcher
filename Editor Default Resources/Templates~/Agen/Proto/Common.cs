using ProtoBuf;
using ProtoBuf.Extension;
using System.Collections.Generic;

namespace Game.Proto
{
    /// <summary>
    /// 消息错误
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.MessageErrorNotify)]
    public partial class MessageErrorNotify : Object, IMessage
    {
        [ProtoMember(1)]
        public string Cmd { get; set; }

        [ProtoMember(2)]
        public int ErrorCode { get; set; }
    }

    /// <summary>
    /// ping消息
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.PingReq)]
    [MessageResponseType(ProtoOpcode.PingResp)]
    public partial class PingReq : Object, IMessage
    {
        /// <summary>
        /// 数据
        /// </summary>
        [ProtoMember(1)]
        public string Str { get; set; }
    }

    /// <summary>
    /// ping回复 sec_time + milli_time = 最终时间
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.PingResp)]
    public partial class PingResp : Object, IMessage
    {
        /// <summary>
        /// 回传
        /// </summary>
        [ProtoMember(1)]
        public string Str { get; set; }

        /// <summary>
        /// 秒值
        /// </summary>
        [ProtoMember(2)]
        public int SecTime { get; set; }

        /// <summary>
        /// 毫秒值
        /// </summary>
        [ProtoMember(3)]
        public int MilliTime { get; set; }
    }

    /// <summary>
    /// 握手
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.HandshakeReq)]
    [MessageResponseType(ProtoOpcode.HandshakeResp)]
    public partial class HandshakeReq : Object, IMessage
    {
        [ProtoMember(1)]
        public string Token { get; set; }
    }

    [ProtoContract]
    [Message(ProtoOpcode.HandshakeResp)]
    public partial class HandshakeResp : Object, IMessage
    {
        [ProtoMember(1)]
        public int Code { get; set; }
    }

    /// <summary>
    /// 服务端主动踢下线前发送此协议
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.KickNotify)]
    public partial class KickNotify : Object, IMessage
    {
        [ProtoMember(1)]
        public string Reason { get; set; }
    }

    /// <summary>
    /// 请求服务器时间
    /// </summary>
    [ProtoContract]
    [Message(ProtoOpcode.GetServerTimeReq)]
    [MessageResponseType(ProtoOpcode.GetServerTimeResp)]
    public partial class GetServerTimeReq : Object, IMessage
    {
    }

    [ProtoContract]
    [Message(ProtoOpcode.GetServerTimeResp)]
    public partial class GetServerTimeResp : Object, IMessage
    {
        [ProtoMember(1)]
        public ulong ServerTime { get; set; }
    }
}