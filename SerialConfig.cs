using YamlDotNet.Serialization;

namespace GeniSerialTest
{
    public class SerialConfig
    {
        [YamlMember(Alias = "commands")]
        public List<CommandResponse> Commands { get; set; } = new List<CommandResponse>();
    }

    public class CommandResponse
    {
        [YamlMember(Alias = "receive")]
        public string Receive { get; set; } = string.Empty;

        [YamlMember(Alias = "send")]
        public string Send { get; set; } = string.Empty;

        [YamlMember(Alias = "description")]
        public string Description { get; set; } = string.Empty;
    }
}