using Luban;

namespace Game.Config
{
    /// <summary>
    /// 角色配置
    /// </summary>
    public sealed partial class ActorConfig : BeanBase
    {
        public ActorConfig(ByteBuf buf)
        {
            id = buf.ReadInt();
            name = buf.ReadString();
            type = buf.ReadInt();
            bean = buf.ReadString();
            attributeId = buf.ReadInt();
            resourceId = buf.ReadInt();

            PostInit();
        }

        public static ActorConfig DeserializeActorConfig(ByteBuf buf)
        {
            return new ActorConfig(buf);
        }

        /// <summary>
        /// 角色标识
        /// </summary>
        public readonly int id;

        /// <summary>
        /// 角色名称
        /// </summary>
        public readonly string name;

        /// <summary>
        /// 角色类型
        /// </summary>
        public readonly int type;

        /// <summary>
        /// 实体名称
        /// </summary>
        public readonly string bean;

        /// <summary>
        /// 属性引用标识
        /// </summary>
        public readonly int attributeId;

        /// <summary>
        /// 资源引用标识
        /// </summary>
        public readonly int resourceId;

        /// <summary>
        /// 资源引用标识
        /// </summary>
        public ResourceConfig ResourceConfig => ResourceConfigTable.Get(resourceId);

        public const int Id = -2025343625;

        public override int GetTypeId() => Id;

        public override string ToString()
        {
            return "{ "
            + "id:" + id + ","
            + "name:" + name + ","
            + "type:" + type + ","
            + "bean:" + bean + ","
            + "attributeId:" + attributeId + ","
            + "resourceId:" + resourceId + ","
            + "}";
        }

        partial void PostInit();
    }
}