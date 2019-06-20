using dotNetCore.Services.Database.Models;
using dotNetCore.Services.Interfaces;
using dotNetCore.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotNetCore.Controllers
{
  public class LoginController : Controller
  {
    private readonly IUserService userService;

    public LoginController(IUserService userService)
    {
      this.userService = userService;
    }

    /// <summary>
    /// 登入頁
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
      if (User.Identity.IsAuthenticated)
      {
        return RedirectToAction("Index", "Main");
      }
      return View();
    }

    /// <summary>
    /// 登入行為
    /// </summary>
    /// <param name="Login"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Index(LoginView login)
    {
      if (!ModelState.IsValid) return View();

      var account = await userService.LoginAsync(login.account, login.password);

      if (account == null)
      {
        ModelState.AddModelError(string.Empty, "帳號或密碼輸入錯誤");
        return View();
      }

      await SignInAsync(account);

      // 加上 Url.IsLocalUrl 防止 Open Redirect 漏洞
      if (!string.IsNullOrWhiteSpace(login.returnUrl) && Url.IsLocalUrl(login.returnUrl))
      {
        return Redirect(login.returnUrl);
      }
      else
      {
        return RedirectToAction("Index", "Main");
      }
    }

    /// <summary>
    /// 登出
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return RedirectToAction("Index", "Login");
    }

    /// <summary>
    /// 登入狀態寫入Cookie
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task SignInAsync(User user)
    {
      var claims = new List<Claim>
      {
        new Claim("Gid", user.Gid.ToString()),
        new Claim(ClaimTypes.Name, user.Account),
        new Claim(ClaimTypes.Role, user.Role.ToString()),
        new Claim("Sex", user.Sex.ToString()),
        new Claim("NickName", user.NickName ?? ""),
        new Claim("Mobile", user.Mobile ?? ""),
        new Claim("Email", user.Email ?? ""),
      };
      var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
      identity.AddClaims(claims);
      var principal = new ClaimsPrincipal(identity);
      await HttpContext.SignInAsync(principal);
    }
  }
}
