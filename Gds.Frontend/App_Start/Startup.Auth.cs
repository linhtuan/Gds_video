using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;

namespace Gds.Frontend
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);


            app.UseFacebookAuthentication(new FacebookAuthenticationOptions
            {
                AppId = "866483453480629",
                AppSecret = "35a32fe9a777a7ef3a28adff41a1625d",
                Scope = { "email" },
                Provider = new FacebookAuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        context.Identity.AddClaim(new Claim("FacebookAccessToken", context.AccessToken));
                        return Task.FromResult(true);
                    }
                }
            });

            var googleOAuth2AuthenticationOptions = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = "343491644981-u6un8q6r1r739i2elnug7cj81ljmmvdi.apps.googleusercontent.com",
                ClientSecret = "k7IQxZk1Eh1yhz2Pd-Mqf_aA",
            };

            googleOAuth2AuthenticationOptions.Scope.Add("email");
            app.UseGoogleAuthentication(googleOAuth2AuthenticationOptions);
        }
    }
}