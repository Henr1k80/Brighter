﻿using System;
using System.Configuration;
using Amazon;
using Amazon.Runtime;
using Paramore.Brighter.MessagingGateway.AWSSQS;
using Paramore.Brighter.Tranformers.AWS;

namespace Paramore.Brighter.AWS.Tests.Helpers;

public class GatewayFactory
{
    public static AWSMessagingGatewayConnection CreateFactory()
    {
        var (credentials, region) = CredentialsChain.GetAwsCredentials();
        return CreateFactory(credentials, region, config => { });
    }

    public static AWSMessagingGatewayConnection CreateFactory(Action<ClientConfig> clientConfig)
    {
        var (credentials, region) = CredentialsChain.GetAwsCredentials();
        return CreateFactory(credentials, region, clientConfig);
    }

    public static AWSMessagingGatewayConnection CreateFactory(
        AWSCredentials credentials,
        RegionEndpoint region,
        Action<ClientConfig>? config = null)
    {
        return new AWSMessagingGatewayConnection(credentials, region,
            cfg =>
            {
                config?.Invoke(cfg);

                /*var serviceURL = Environment.GetEnvironmentVariable("LOCALSTACK_SERVICE_URL");
                if (!string.IsNullOrWhiteSpace(serviceURL))
                {
                    cfg.ServiceURL = serviceURL;
                }*/
            });
    }

    public static AWSS3Connection CreateS3Connection()
    {
        var (credentials, region) = CredentialsChain.GetAwsCredentials();
        return new AWSS3Connection(credentials, region);
    }
}
