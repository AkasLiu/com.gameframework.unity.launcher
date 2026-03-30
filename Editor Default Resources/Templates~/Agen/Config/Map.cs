using Luban;
using System.Collections.Generic;

namespace Game.Config
{
    /// <summary>
    /// 地图配置表
    /// </summary>
    [Config]
    public partial class MapConfigTable : ConfigSingleton<MapConfigTable>
    {
        private readonly List<MapConfig> _dataList;
        private readonly Dictionary<int, MapConfig> _dataMap;

        public MapConfigTable(ByteBuf buf)
        {
            _dataList = new List<MapConfig>();
            _dataMap = new Dictionary<int, MapConfig>();

            for (int n = buf.ReadSize(); n > 0; --n)
            {
                MapConfig v;
                v = MapConfig.DeserializeMapConfig(buf);
                _dataList.Add(v);
                _dataMap.Add(v.id, v);
            }

            PostInit();
        }

        public static List<MapConfig> DataList => Instance._dataList;

        public static Dictionary<int, MapConfig> DataMap => Instance._dataMap;

        public static MapConfig Get(int key) => Instance._dataMap.GetValueOrDefault(key);

        partial void PostInit();
    }
}