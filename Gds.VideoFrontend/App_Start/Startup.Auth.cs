using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;

namespace Gds.VideoFrontend
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
                LoginPath = new PathString("/Account/Login"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30)
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
                },
                BackchannelTimeout = TimeSpan.FromMinutes(30)
            });

            var googleOAuth2AuthenticationOptions = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = "725371161805-u7bjg329mk61n30gavg9o09hutppb8a5.apps.googleusercontent.com",
                ClientSecret = "kClgGaoXD32LmamkF5vXKEQ3",
                Provider = new GoogleOAuth2AuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        context.Identity.AddClaim(new Claim("Google_AccessToken", context.AccessToken));
                        return Task.FromResult(true);
                    }
                },
                BackchannelTimeout = TimeSpan.FromMinutes(30),
            };

            googleOAuth2AuthenticationOptions.Scope.Add("email");
            googleOAuth2AuthenticationOptions.Scope.Add("profile");
            app.UseGoogleAuthentication(googleOAuth2AuthenticationOptions);
        }
    }
}