using Amazon.SecurityToken.Model;
using Microsoft.Extensions.Configuration;
using AssumeRoleRequest = Without.Systems.SecurityToken.Structures.AssumeRoleRequest;

namespace Without.Systems.SecurityToken.Test;

public class Tests
{
    private static readonly ISecurityToken _actions = new SecurityToken();

    private Structures.AwsCredentials _credentials;
    
    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();

        string awsAccessKey = configuration["AWSAccessKey"] ?? throw new InvalidOperationException();
        string awsSecretAccessKey = configuration["AWSSecretAccessKey"] ?? throw new InvalidOperationException();

        _credentials = new Structures.AwsCredentials(awsAccessKey, awsSecretAccessKey);
    }
    
    [Test]
    public void AssumeRoleSimple_Test()
    {
        Structures.AssumeRoleRequest request = new AssumeRoleRequest
        {
            DurationSeconds = 1200,
            RoleArn = "<role arn>",
            RoleSessionName = "sample-session"
        };

        Structures.AssumeRoleResponse response = _actions.AssumeRole(_credentials, "eu-central-1", request);
    }
   
}