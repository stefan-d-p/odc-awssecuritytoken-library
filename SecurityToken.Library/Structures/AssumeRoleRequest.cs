using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SecurityToken.Structures;

[OSStructure(Description = "Container for the parameters to the AssumeRole operation.")]
public struct AssumeRoleRequest : IEquatable<AssumeRoleRequest>
{
    [OSStructureField(
        Description =
            "The duration, in seconds, of the role session. The value specified can range from 900 seconds (15 minutes) up to the maximum session duration set for the role",
        DataType = OSDataType.Integer,
        IsMandatory = false,
        DefaultValue = "900")]
    public int DurationSeconds = 900;

    [OSStructureField(
        Description = "A unique identifier that might be required when you assume a role in another account.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ExternalId = string.Empty; 
    
    [OSStructureField(Description = "An IAM policy in JSON format that you want to use as an inline session policy.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Policy = String.Empty;
    
    [OSStructureField(Description = "The Amazon Resource Names (ARNs) of the IAM managed policies that you want to useas managed session policies.",
        IsMandatory = false)]
    public List<PolicyDescriptorType> PolicyArns = new List<PolicyDescriptorType>();

    [OSStructureField(
        Description = "A list of previously acquired trusted context assertions in the format of a JSON array.",
        IsMandatory = false)]
    public List<ProvidedContext> ProvidedContexts = new List<ProvidedContext>();

    [OSStructureField(Description = "The Amazon Resource Name (ARN) of the role to assume.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string RoleArn = string.Empty;

    [OSStructureField(Description = "An identifier for the assumed role session.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string RoleSessionName = string.Empty;

    [OSStructureField(
        Description =
            "The identification number of the MFA device that is associated with the user who is making the AssumeRole call.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string SerialNumber = string.Empty;

    [OSStructureField(
        Description = "The source identity specified by the principal that is calling the AssumeRole operation.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string SourceIdentity = string.Empty;

    [OSStructureField(Description = "A list of session tags that you want to pass.",
        IsMandatory = false)]
    public List<Tag> Tags = new List<Tag>();

    [OSStructureField(
        Description =
            "The value provided by the MFA device, if the trust policy of the role being assumed requires MFA.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string TokenCode = string.Empty;

    [OSStructureField(Description = "A list of keys for session tags that you want to set as transitive.",
        IsMandatory = false)]
    public List<string> TransitiveTagKeys = new List<string>();

    [OSIgnore]
    public AssumeRoleRequest()
    {
        
    }

    [OSIgnore]
    public bool Equals(AssumeRoleRequest other)
    {
        return DurationSeconds == other.DurationSeconds && ExternalId == other.ExternalId && Policy == other.Policy &&
               PolicyArns.SequenceEqual(other.PolicyArns) && ProvidedContexts.SequenceEqual(other.ProvidedContexts) &&
               RoleArn == other.RoleArn && RoleSessionName == other.RoleSessionName &&
               SerialNumber == other.SerialNumber && SourceIdentity == other.SourceIdentity &&
               Tags.SequenceEqual(other.Tags) && TokenCode == other.TokenCode &&
               TransitiveTagKeys.SequenceEqual(other.TransitiveTagKeys);
    }

    [OSIgnore]
    public override bool Equals(object? obj)
    {
        return obj is AssumeRoleRequest other && Equals(other);
    }

    [OSIgnore]
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(DurationSeconds);
        hashCode.Add(ExternalId);
        hashCode.Add(Policy);
        hashCode.Add(PolicyArns);
        hashCode.Add(ProvidedContexts);
        hashCode.Add(RoleArn);
        hashCode.Add(RoleSessionName);
        hashCode.Add(SerialNumber);
        hashCode.Add(SourceIdentity);
        hashCode.Add(Tags);
        hashCode.Add(TokenCode);
        hashCode.Add(TransitiveTagKeys);
        return hashCode.ToHashCode();
    }
}

