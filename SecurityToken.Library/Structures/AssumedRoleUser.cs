using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SecurityToken.Structures;

[OSStructure(Description = "The identifiers for the temporary security credentials that the operation returns.")]
public struct AssumedRoleUser
{
    [OSStructureField(
        Description = "The ARN of the temporary security credentials that are returned from the AssumeRole action.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Arn;
    
    [OSStructureField(Description = " A unique identifier that contains the role ID and the role session name of the role that is being assumed.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string AssumedRoleId;
}