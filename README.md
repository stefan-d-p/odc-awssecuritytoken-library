# OutSystems Developer Cloud External Logic Connector for AWS IAM Security Token Service

This external logic connector wraps the offical AWS .NET SDK for IAM Security Token Service

## Actions
The library exposes the following actions

### AssumeRole

Retrieves an object from Amazon S3

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `assumeRoleRequest` - AssumeRole Request Parameters.

**Result**

* `result` - AssumeRole result structure
