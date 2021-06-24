using Aspose.Email.Cloud.Sdk.Api;
using Aspose.Email.Cloud.Sdk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;

namespace AsposeEmailDotnet5.Services
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }

    public interface IAsposeEmailCloudApiService
    {
        Stream Convert(Stream file, string fromFormat, string toFormat);
    }


    public class AsposeEmailCloudApiService : IAsposeEmailCloudApiService
    {
        public readonly EmailCloud EmailCloudApi;

        public AsposeEmailCloudApiService(IConfiguration config)
        {
            string ClientId = config["AsposeEmailUserData:ClientId"];
            string ClientSecret = config["AsposeEmailUserData:ClientSecret"];

            EmailCloudApi = new EmailCloud(clientSecret: ClientSecret, clientId: ClientId);
        }

        public Stream Convert(Stream file, string fromFormat, string toFormat)
        {
            EmailConvertRequest ecr = new EmailConvertRequest()
            {
                File = file,
                FromFormat = fromFormat,
                ToFormat = toFormat
            };

            var convertResult = EmailCloudApi.Email.Convert(ecr);
            return convertResult;
        }
    }
}