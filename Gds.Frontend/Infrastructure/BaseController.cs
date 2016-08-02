using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gds.Setting;
using Gds.Frontend.Domain;
using Gds.Frontend.Models;

namespace Gds.Frontend.Infrastructure
{
    public class BaseController : Controller
    {
        protected List<string> Categorys
        {
            get { return (List<string>)SessionManager.GetSessionObject(SessionObjectEnum.Categorys); }
        }

        public List<CategoryLeftMenuViewModel> GetLeftMenu()
        {
            var leftMenu = new List<CategoryLeftMenuViewModel>();
            if (Categorys != null)
            {
                leftMenu.AddRange(Categorys.Select(item => item.Split('+')).Select(categoryObj => new CategoryLeftMenuViewModel
                {
                    CategoryName = categoryObj[0],
                    UrlCategory = categoryObj[1]
                }));
                return leftMenu;
            }
            var service = DependencyResolver.Current.GetService(typeof(ICategoryService)) as ICategoryService;
            leftMenu = service.GetLeftMenu();
            var leftMenuSession = leftMenu.Select(item => string.Format("{0}+{1}", item.CategoryName, item.UrlCategory)).ToList();
            SessionManager.SetSessionObject(SessionObjectEnum.Categorys, leftMenuSession);
            return leftMenu;
        }
    }
}