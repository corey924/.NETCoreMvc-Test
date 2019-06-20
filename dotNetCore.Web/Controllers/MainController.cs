using dotNetCore.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotNetCore.Controllers
{
  [Authorize]
  public class MainController : BaseController
  {
    public IActionResult Index()
    {
      ViewData["Account"] = UserData.Account;
      ViewData["NickName"] = UserData.NickName;
      return View();
    }
  }
}
