using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Facebook;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Gds.VideoFrontend.Controllers
{
    public class AccountController : Controller
    {

        private string _provider = string.Empty;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return null;
        }

        public ActionResult Login()
        {
            return null;
        }

        public ActionResult Logout()
        {
            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            _provider = provider;
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var info = await AuthenticationManager.GetExternalLoginInfoAsync();
            switch (info.Login.LoginProvider.ToUpper())
            {
                case "FACEBOOK":
                    var identityFb = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
                    var emailFb = identityFb.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
                    var accessTokenFb = identityFb.FindFirstValue("FacebookAccessToken");
                    var fb = new FacebookClient(accessTokenFb);
                    dynamic myInfoFb = fb.Get("/me?fields=email,first_name,last_name,gender"); // specify the email field
                    break;
                case "GOOGLE":
                    var identityGG = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
                    var emailGG = identityGG.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
                    var accessTokenGG = identityGG.FindFirstValue("FacebookAccessToken");
                    break;
                default:

                    break;
            }
            AuthenticationManager.SignOut();
            return null;
        }

        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            private ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            private string LoginProvider { get; set; }
            private string RedirectUri { get; set; }
            private string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
    }
}