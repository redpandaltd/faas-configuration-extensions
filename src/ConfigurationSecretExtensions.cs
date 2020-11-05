using System;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationSecretExtensions
    {
        public static byte[] GetSecret( this IConfiguration configuration, string secretName )
        {
            var valueBase64 = configuration[ $"openfaas_secret_{secretName}" ];

            if ( valueBase64 == null )
            {
                return ( null );
            }

            return Convert.FromBase64String( valueBase64 );
        }

        public static string GetSecretAsString( this IConfiguration configuration, string secretName )
        {
            var value = GetSecret( configuration, secretName );

            if ( value == null )
            {
                return ( null );
            }

            return Encoding.UTF8.GetString( value );
        }
    }
}
