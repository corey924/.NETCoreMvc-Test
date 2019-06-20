using dotNetCore.IdentityPrincipal;
using dotNetCore.Services.Database.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace dotNetCore.Web.Controllers
{
  [Authorize]
  public class BaseController : Controller
  {
    internal virtual CustomPrincipal UserData
    {
      get
      {
        return new CustomPrincipal()
        {
          Gid = new Guid(User.Claims.FirstOrDefault(c => c.Type.Equals("Gid")).Value),
          Account = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value,
          //Role = (Role)Enum.Parse(typeof(Role), User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role)).Value),
          Sex = (Sex)Enum.Parse(typeof(Sex), User.Claims.FirstOrDefault(c => c.Type.Equals("Sex")).Value),
          NickName = User.Claims.FirstOrDefault(c => c.Type.Equals("NickName")).Value,
          Mobile = User.Claims.FirstOrDefault(c => c.Type.Equals("Mobile")).Value,
          Email = User.Claims.FirstOrDefault(c => c.Type.Equals("Email")).Value
        };
      }
    }
  }
}