using Luban;
using System.Collections.Generic;

namespace Game.Config
{
    /// <summary>
    /// 角色配置表
    /// </summary>
    [Config]
    public partial class ActorConfigTable : ConfigSingleton<ActorConfigTable>
    {
        private readonly List<ActorConfig> _dataList;
        private readonly Dictionary<int, ActorConfig> _dataMap;

        public ActorConfigTable(ByteBuf buf)
        {
            _dataList = new List<ActorConfig>();
            _dataMap = new Dictionary<int, ActorConfig>();

            for (int n = buf.ReadSize(); n > 0; --n)
            {
                ActorConfig v;
                v = ActorConfig.DeserializeActorConfig(buf);
                _dataList.Add(v);
                _dataMap.Add(v.id, v);
            }

            PostInit();
        }

        public static List<ActorConfig> DataList => Instance._dataList;

        public static Dictionary<int, ActorConfig> DataMap => Instance._dataMap;

        public static ActorConfig Get(int key) => Instance._dataMap.GetValueOrDefault(key);

        partial void PostInit();
    }
}