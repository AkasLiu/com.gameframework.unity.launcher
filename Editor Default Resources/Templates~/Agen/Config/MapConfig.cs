using Luban;

namespace Game.Config
{
    /// <summary>
    /// 地图配置
    /// </summary>
    public sealed partial class MapConfig : BeanBase
    {
        public MapConfig(ByteBuf buf)
        {
            id = buf.ReadInt();
            name = buf.ReadString();
            resourceId = buf.ReadInt();

            PostInit();
        }

        public static MapConfig DeserializeMapConfig(ByteBuf buf)
        {
            return new MapConfig(buf);
        }

        /// <summary>
        /// 地图标识
        /// </summary>
        public readonly int id;

        /// <summary>
        /// 地图名称
        /// </summary>
        public readonly string name;

        /// <summary>
        /// 资源引用标识
        /// </summary>
        public readonly int resourceId;

        /// <summary>
        /// 资源引用标识
        /// </summary>
        public ResourceConfig ResourceConfig => ResourceConfigTable.Get(resourceId);

        public const int Id = -1840922722;

        public override int GetTypeId() => Id;

        public override string ToString()
        {
            return "{ "
            + "id:" + id + ","
            + "name:" + name + ","
            + "resourceId:" + resourceId + ","
            + "}";
        }

        partial void PostInit();
    }
}