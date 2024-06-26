using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SecurityToken.Structures;

[OSStructure(Description = "Amazon Web Services credentials for API authentication.")]
public struct Credentials
{
    [OSStructureField(Description = "The access key ID that identifies the temporary security credentials.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string AccessKeyId;
    
    [OSStructureField(Description = "The date on which the current credentials expire.",
        DataType = OSDataType.DateTime,
        IsMandatory = true)]
    public DateTime Expiration;
    
    [OSStructureField(Description = "The secret access key that can be used to sign requests.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string SecretAccessKey;
    
    [OSStructureField(Description = "The token that users must pass to the service API to use the temporary credentials.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string SessionToken;
    
}