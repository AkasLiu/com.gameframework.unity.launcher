using Luban;
using System.Collections.Generic;

namespace Game.Config
{
    /// <summary>
    /// 属性配置表
    /// </summary>
    [Config]
    public partial class AttributeConfigTable : ConfigSingleton<AttributeConfigTable>
    {
        private readonly List<AttributeConfig> _dataList;
        private readonly Dictionary<int, AttributeConfig> _dataMap;

        public AttributeConfigTable(ByteBuf buf)
        {
            _dataList = new List<AttributeConfig>();
            _dataMap = new Dictionary<int, AttributeConfig>();

            for (int n = buf.ReadSize(); n > 0; --n)
            {
                AttributeConfig v;
                v = AttributeConfig.DeserializeAttributeConfig(buf);
                _dataList.Add(v);
                _dataMap.Add(v.id, v);
            }

            PostInit();
        }

        public static List<AttributeConfig> DataList => Instance._dataList;

        public static Dictionary<int, AttributeConfig> DataMap => Instance._dataMap;

        public static AttributeConfig Get(int key) => Instance._dataMap.GetValueOrDefault(key);

        partial void PostInit();
    }
}