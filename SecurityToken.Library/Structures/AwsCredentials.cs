using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SecurityToken.Structures;

[OSStructure(
    Description = "AWS IAM Credentials")]
public struct AwsCredentials
{
    [OSStructureField(
        Description = "Access Key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string AccessKey;

    [OSStructureField(
        Description = "Secret Access Key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string SecretAccessKey;
    
    [OSStructureField(
        Description = "(Optional) Session Token",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? SessionToken;
   

    [OSIgnore]
    public bool IsValid => !string.IsNullOrEmpty(AccessKey) && !string.IsNullOrEmpty(SecretAccessKey);
    
    [OSIgnore]
    public AwsCredentials(string accessKey, string secretAccessKey, string? sessionToken = null)
    {
        AccessKey = accessKey;
        SecretAccessKey = secretAccessKey;
        SessionToken = sessionToken;
    }
    
}