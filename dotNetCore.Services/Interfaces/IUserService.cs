using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using dotNetCore.Services.Database.Entity;
using dotNetCore.Services.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetCore.Services.Interfaces
{
  public interface IUserService : IEntityService<User>
  {
    /// <summary>
    /// 登入並取得使用者資料
    /// </summary>
    /// <param name="account">帳號</param>
    /// <param name="password">密碼</param>
    /// <returns></returns>
    Task<User> LoginAsync(string account, string password);
  }
}
