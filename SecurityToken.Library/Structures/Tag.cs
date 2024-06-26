using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SecurityToken.Structures;

[OSStructure(Description = "You can pass custom key-value pair attributes when you assume a role or federate a user.")]
public struct Tag
{
    [OSStructureField(Description = "The key for a session tag.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;
    
    [OSStructureField(Description = "The value for a session tag.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Value;
}