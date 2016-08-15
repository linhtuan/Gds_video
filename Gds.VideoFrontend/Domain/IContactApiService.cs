using Gds.VideoFrontend.Models;

namespace Gds.VideoFrontend.Domain
{
    public interface IContactApiService
    {
        ContactViewModel LoginAction(string userName, string password);
        //bool LoginAuthenticationFacebook();

        ContactViewModel LoginAuthentication(IdentityUserModel model);
    }
}