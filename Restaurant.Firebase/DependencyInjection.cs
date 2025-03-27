using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Restaurant.Firebase
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFirebase(this IServiceCollection services)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("chipipi-51eec-firebase-adminsdk-fbsvc-9e781c9737.json")
            });


            return services;
        }
    }
}
