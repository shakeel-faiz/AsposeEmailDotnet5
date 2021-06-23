using Aspose.Email.Cloud.Sdk.Api;
using Aspose.Email.Cloud.Sdk.Model;
using Microsoft.AspNetCore.Http;
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
        private string ClientId = "81e42949-3dc6-4080-b1d7-1c2c30cd954c";
        private string ClientSecret = "6af97636186e5ea2ad642ad64fd0aa17";

        public EmailCloud EmailCloudApi
        {
            get
            {
                ISession session = HttpContextAccessor.HttpContext.Session;

                string strEmailCloudSessionKey = nameof(strEmailCloudSessionKey);

                EmailCloud emailCloudApi = session.Get<EmailCloud>(strEmailCloudSessionKey);

                if (emailCloudApi == null)
                {
                    emailCloudApi = new EmailCloud(clientSecret: ClientSecret, clientId: ClientId);
                    session.Set<EmailCloud>(strEmailCloudSessionKey, emailCloudApi);
                }

                return emailCloudApi;
            }
        }

        private IHttpContextAccessor HttpContextAccessor { get; }

        public AsposeEmailCloudApiService(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
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