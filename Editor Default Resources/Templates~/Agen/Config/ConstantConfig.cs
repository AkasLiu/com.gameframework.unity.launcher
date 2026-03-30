using Luban;

namespace Game.Config
{
    /// <summary>
    /// 常量配置
    /// </summary>
    public sealed partial class ConstantConfig : BeanBase
    {
        public ConstantConfig(ByteBuf buf)
        {
            version = buf.ReadString();

            PostInit();
        }

        public static ConstantConfig DeserializeConstantConfig(ByteBuf buf)
        {
            return new ConstantConfig(buf);
        }

        /// <summary>
        /// 版本号
        /// </summary>
        public readonly string version;

        public const int Id = -1411722202;

        public override int GetTypeId() => Id;

        public override string ToString()
        {
            return "{ "
            + "version:" + version + ","
            + "}";
        }

        partial void PostInit();
    }
}