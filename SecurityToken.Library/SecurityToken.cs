using System.Net;
using Amazon;
using Amazon.Runtime;
using Amazon.SecurityToken;
using AutoMapper;
using Without.Systems.SecurityToken.Extensions;
using Without.Systems.SecurityToken.Util;

namespace Without.Systems.SecurityToken;

public class SecurityToken : ISecurityToken
{

    private IMapper _mapper;

    public SecurityToken()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Structures.Tag, Amazon.SecurityToken.Model.Tag>();
            
            cfg.CreateMap<Structures.ProvidedContext, Amazon.SecurityToken.Model.ProvidedContext>()
                .ForMember(dest => dest.ProviderArn, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ProviderArn)))
                .ForMember(dest => dest.ContextAssertion, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ContextAssertion)));
            cfg.CreateMap<Structures.PolicyDescriptorType, Amazon.SecurityToken.Model.PolicyDescriptorType>();

            cfg.CreateMap<Structures.AssumeRoleRequest, Amazon.SecurityToken.Model.AssumeRoleRequest>()
                .ForMember(dest => dest.DurationSeconds, opt => opt.Condition(src => src.DurationSeconds > 0))
                .ForMember(dest => dest.ExternalId, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ExternalId)))
                .ForMember(dest => dest.Policy, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Policy)))
                .ForMember(dest => dest.PolicyArns, opt => opt.Condition(src => src.PolicyArns.Count > 0))
                .ForMember(dest => dest.ProvidedContexts, opt => opt.Condition(src => src.ProvidedContexts.Count > 0))
                .ForMember(dest => dest.RoleSessionName,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.RoleSessionName)))
                .ForMember(dest => dest.SerialNumber,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.SerialNumber)))
                .ForMember(dest => dest.Tags, opt => opt.Condition(src => src.Tags.Count > 0))
                .ForMember(dest => dest.TokenCode, opt => opt.Condition(src => !string.IsNullOrEmpty(src.TokenCode)))
                .ForMember(dest => dest.TransitiveTagKeys,
                    opt => opt.Condition(src => src.TransitiveTagKeys.Count > 0))
                .ForMember(dest => dest.SourceIdentity, opt => opt.Condition(src => !string.IsNullOrEmpty(src.SourceIdentity)));

            cfg.CreateMap<Amazon.SecurityToken.Model.AssumedRoleUser, Structures.AssumedRoleUser>();
            cfg.CreateMap<Amazon.SecurityToken.Model.Credentials, Structures.Credentials>();
            cfg.CreateMap<Amazon.SecurityToken.Model.AssumeRoleResponse, Structures.AssumeRoleResponse>();
            

        });
        
        _mapper = mapperConfiguration.CreateMapper();
    }

    public Structures.AssumeRoleResponse AssumeRole(Structures.AwsCredentials credentials, string region,
        Structures.AssumeRoleRequest assumeRoleRequest)
    {
        AmazonSecurityTokenServiceClient client = GetSecurityTokenServiceClient(credentials, region);
        Amazon.SecurityToken.Model.AssumeRoleRequest request =
            _mapper.Map<Amazon.SecurityToken.Model.AssumeRoleRequest>(assumeRoleRequest);
        Amazon.SecurityToken.Model.AssumeRoleResponse response =
            AsyncUtil.RunSync(() => client.AssumeRoleAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.AssumeRoleResponse>(response);
        
    }
   
    private AmazonSecurityTokenServiceClient GetSecurityTokenServiceClient(Structures.AwsCredentials credentials, string region) =>
        new AmazonSecurityTokenServiceClient(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));
    
    private void ParseResponse(AmazonWebServiceResponse response)
    {
        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) || response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error in operation ({response.HttpStatusCode})");
    }
}