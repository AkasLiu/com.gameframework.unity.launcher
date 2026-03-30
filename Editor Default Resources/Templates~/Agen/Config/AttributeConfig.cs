using Luban;

namespace Game.Config
{
    /// <summary>
    /// 属性配置
    /// </summary>
    public sealed partial class AttributeConfig : BeanBase
    {
        public AttributeConfig(ByteBuf buf)
        {
            id = buf.ReadInt();
            exp = buf.ReadInt();
            speed = buf.ReadInt();
            attack = buf.ReadInt();
            defense = buf.ReadInt();

            PostInit();
        }

        public static AttributeConfig DeserializeAttributeConfig(ByteBuf buf)
        {
            return new AttributeConfig(buf);
        }

        /// <summary>
        /// 属性标识
        /// </summary>
        public readonly int id;

        /// <summary>
        /// 经验
        /// </summary>
        public readonly int exp;

        /// <summary>
        /// 速度
        /// </summary>
        public readonly int speed;

        /// <summary>
        /// 攻击
        /// </summary>
        public readonly int attack;

        /// <summary>
        /// 防御
        /// </summary>
        public readonly int defense;

        public const int Id = 1818455262;

        public override int GetTypeId() => Id;

        public override string ToString()
        {
            return "{ "
            + "id:" + id + ","
            + "exp:" + exp + ","
            + "speed:" + speed + ","
            + "attack:" + attack + ","
            + "defense:" + defense + ","
            + "}";
        }

        partial void PostInit();
    }
}