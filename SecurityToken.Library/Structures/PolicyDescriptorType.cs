using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SecurityToken.Structures;

[OSStructure(Description = "A reference to the IAM managed policy that is passed as a session policy for a role session or a federated user session.")]
public struct PolicyDescriptorType
{
    [OSStructureField(
        Description =
            "The Amazon Resource Name (ARN) of the IAM managed policy to use as a session policyfor the role.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Arn;
}