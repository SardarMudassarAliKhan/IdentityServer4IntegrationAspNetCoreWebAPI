using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer4IntegrationAspNetCoreWebAPI.Configurations
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
        new List<TestUser>
        {
        new TestUser
        {
            SubjectId = "1144",
            Username = "MudassarAli",
            Password = "Smak2050@@",
            Claims =
            {
                new Claim(JwtClaimTypes.Name, "Sardar Mudassar Ali Khan"),
                new Claim(JwtClaimTypes.GivenName, "Sardar Mudassar Ali Khan"),
                new Claim(JwtClaimTypes.FamilyName, "SMAK"),
                new Claim(JwtClaimTypes.WebSite, "https://www.c-sharpcorner.com/members/mudassar-ali4"),
            }
        }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("myApi.read"),
            new ApiScope("myApi.write"),
        };

        public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("myApi")
            {
                Scopes = new List<string>{ "myApi.read","myApi.write" },
                ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
            }
        };

        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "smak.client",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "myApi.read" }
            },
        };

    }
}
