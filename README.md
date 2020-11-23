# OpenFaaS Configuration Extensions

This is part of OpenFaaS ASPNET Template. It provides configuration extensions.

## Installing

Add a package reference from NuGet

```
dotnet add package Redpanda.Extensions.OpenFaaS.Configuration
```

## Secrets

Secrets that the function has access to are lodaded into ASPNET's configuration model. Although they can be manually retrieved, this extension simplifies the process, particularly because they are stored as a base64 string, supporting both binary and text content.

```csharp
public void ConfigureServices( IServiceCollection services )
{
    services.AddTransient<IHttpFunction, Function>();

    // add your services here.
    services.AddMyService( options =>
    {
        // reads the secret as it was stored, a byte[]
        options.BinaryCertificate = Configuration.GetSecret( "secret-certificate" );
    } );

    services.AddMyOtherService( options =>
    {
        // reads the secret as text using UTF8 encoding
        options.ApiKey = Configuration.GetSecretAsString( "secret-certificate" );
    } );
}
```
