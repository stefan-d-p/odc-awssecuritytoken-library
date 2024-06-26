using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SecurityToken.Structures;

[OSStructure(Description = "Contains the response to a successful <a>AssumeRole</a> request, including temporary Amazon Web Services credentials that can be used to make Amazon Web Services requests.")]
public struct AssumeRoleResponse
{
    [OSStructureField(Description =
        "The Amazon Resource Name (ARN) and the assumed role ID, which are identifiers that you can use to refer to the resulting temporary security credentials.")]
    public AssumedRoleUser AssumedRoleUser;
    
    [OSStructureField(Description = "he temporary security credentials, which include an access key ID, a secret access key, and a security (or session) token.")]
    public Credentials Credentials;
    
    [OSStructureField(Description = "A percentage value that indicates the packed size of the session policies and session tags combined passed in the request",
        DataType = OSDataType.Integer)]
    public int PackedPolicySize;
    
    [OSStructureField(Description = "The source identity specified by the principal that is calling the AssumeRole operation.",
        DataType = OSDataType.Text)]
    public string SourceIdentity;
    
}