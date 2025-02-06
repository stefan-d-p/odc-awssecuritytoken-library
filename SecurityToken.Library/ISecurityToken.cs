using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SecurityToken
{
    [OSInterface(
        Name = "AWSSecurityToken",
        Description = "AWS provides AWS Security Token Service (AWS STS) as a web service that enables you to request temporary, limited-privilege credentials for users",
        IconResourceName = "Without.Systems.SecurityToken.Resources.IAM.png")]
    public interface ISecurityToken
    {
        [OSAction(
            Description = "Returns a set of temporary security credentials that you can use to access AWS resources",
            ReturnName = "result",
            ReturnDescription = "Temporary Security Credentials Result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.SecurityToken.Resources.IAM.png")]
        Structures.AssumeRoleResponse AssumeRole(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.AwsCredentials credentials,

            [OSParameter(Description = "AWS Region System Name",
                DataType = OSDataType.Text)]
            string region,
            
            [OSParameter(
                Description = "Assume Role Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.AssumeRoleRequest assumeRoleRequest);
    }
}