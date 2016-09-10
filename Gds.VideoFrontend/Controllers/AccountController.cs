using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Facebook;
using Gds.Setting;
using Gds.VideoFrontend.Domain;
using Gds.VideoFrontend.Infrastructure;
using Gds.VideoFrontend.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Gds.VideoFrontend.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IContactApiService _contactApiService;

        public AccountController(IContactApiService contactApiService)
        {
            _contactApiService = contactApiService;
        }

        public PartialViewResult MiniAccountProfile(int pageIndex)
        {
            if (ContactId != null)
            {

                var model = new ContactViewModel();
                model.ContactId = ContactId.Value;
                return PartialView("MiniUserProfilePartialView", model);
            }
            ViewBag.PageIndex = pageIndex;
            return PartialView("MiniUserProfilePartialView", null);
        }

        [HttpPost]
        public JsonResult Login(string userName, string passwords)
        {
            var modelResult = _contactApiService.LoginAction(userName, passwords);
            if(modelResult.ContactId != 0)
            {
                SessionManager.SetSessionObject(SessionObjectEnum.TokenUser, modelResult.TokenUser);
                SessionManager.SetSessionObject(SessionObjectEnum.SecurityCode, modelResult.SecurityCode);
                SessionManager.SetSessionObject(SessionObjectEnum.ContactId, modelResult.ContactId);
                SessionManager.SetSessionObject(SessionObjectEnum.ContactFullName, modelResult.ContactFullName);
                SessionManager.SetSessionObject(SessionObjectEnum.ContactImage, modelResult.ContactImage);
            }
            return modelResult.ContactId != 0
                ? Json(new { isSuccess = true, action = Url.Action("Courses", "Category"), data = modelResult })
                : Json(new { isSuccess = false, msg = modelResult.Message });
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var info = await AuthenticationManager.GetExternalLoginInfoAsync();
            var model = new IdentityUserModel();
            switch (info.Login.LoginProvider.ToUpper())
            {
                case "FACEBOOK":
                    var identity = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
                    var accessToken = identity.FindFirstValue("FacebookAccessToken");
                    var fb = new FacebookClient(accessToken);
                    var myInfo = fb.Get("/me?fields=email,first_name,last_name,gender") as JsonObject; // specify the email field
                    if (myInfo != null)
                    {
                        model.Type = info.Login.LoginProvider.ToUpper();
                        model.Email = myInfo["email"].ToString();
                        model.Name = string.Format("{0} {1}", myInfo["first_name"], myInfo["last_name"]);
                        model.Id = myInfo["id"].ToString();
                        model.Token = accessToken;
                    }
                    break;
                case "GOOGLE":
                    var identityGG = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
                    var emailGG = identityGG.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
                    var name = identityGG.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
                    var id = identityGG.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                    var accessTokenGG = identityGG.FindFirstValue("Google_AccessToken");
                    model.Type = info.Login.LoginProvider.ToUpper();
                    if (emailGG != null) model.Email = emailGG.Value;
                    if (name != null) model.Name = name.Value;
                    if (name != null) model.Id = id.Value;
                    model.Token = accessTokenGG;
                    break;
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                var modelResult = _contactApiService.LoginAuthentication(model);
                SessionManager.SetSessionObject(SessionObjectEnum.TokenUser, modelResult.TokenUser);
                SessionManager.SetSessionObject(SessionObjectEnum.SecurityCode, modelResult.SecurityCode);
                SessionManager.SetSessionObject(SessionObjectEnum.ContactId, modelResult.ContactId);
                SessionManager.SetSessionObject(SessionObjectEnum.ContactFullName, modelResult.ContactFullName);
                SessionManager.SetSessionObject(SessionObjectEnum.ContactImage, modelResult.ContactImage);
                return RedirectToAction("Courses", "Category");
            }

            return View("ExternalLoginConfirmation", model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(IdentityUserModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            var modelResult = _contactApiService.LoginAuthentication(model);
            SessionManager.SetSessionObject(SessionObjectEnum.TokenUser, modelResult.TokenUser);
            SessionManager.SetSessionObject(SessionObjectEnum.SecurityCode, modelResult.SecurityCode);
            SessionManager.SetSessionObject(SessionObjectEnum.ContactId, modelResult.ContactId);

            return RedirectToAction("Courses", "Category");
        } 

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("users/view_profile")]
        public ActionResult ProfileDetail()
        {
            return View();
        }

        [Route("users/edit_profile")]
        public ActionResult EditProfile()
        {
            return View();
        }

        [Route("users/learning")]
        public ActionResult UserCouse()
        {
            return View();
        }

        [Route("users/payment_history")]
        public ActionResult UserPaymentHistory()
        {
            return View();
        }

        [Route("users/payment/{categorytype?}/payment_bill")]
        public ActionResult UserPaymentBill(string categorytype)
        {
            return View();
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

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
        #endregion
    }
}