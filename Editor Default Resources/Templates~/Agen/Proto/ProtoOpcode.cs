namespace Game.Proto
{
    public static class ProtoOpcode
    {
        public const ushort MessageErrorNotify = 1;
        public const ushort PingReq = 2;
        public const ushort PingResp = 3;
        public const ushort HandshakeReq = 4;
        public const ushort HandshakeResp = 5;
        public const ushort KickNotify = 6;
        public const ushort CheckVersionReq = 7;
        public const ushort CheckVersionResp = 8;
        public const ushort ExceptionNotify = 9;
        public const ushort BigPacketNotify = 10;
        public const ushort GetPlayerListReq = 104;
        public const ushort GetPlayerListResp = 105;
        public const ushort CreatePlayerReq = 106;
        public const ushort CreatePlayerResp = 107;
        public const ushort EnterWorldReq = 108;
        public const ushort EnterWorldResp = 109;
        public const ushort ExitWorldReq = 110;
        public const ushort ExitWorldResp = 111;
        public const ushort PlayerInfoSyncNotify = 114;
        public const ushort GetServerTimeReq = 115;
        public const ushort GetServerTimeResp = 116;
        public const ushort PlayerExpChangedNotify = 117;
        public const ushort AreaSpawnNotify = 118;
    }
}