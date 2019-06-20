using dotNetCore.Services.Database.Enum;
using System;
using System.Security.Principal;

namespace dotNetCore.IdentityPrincipal
{
  public class CustomPrincipal : CustomPrincipalSerializeModel, IPrincipal
  {
    public IIdentity Identity { get; private set; }
    public override Role Role { get; set; }
    public bool IsInRole(string roleName)
    {
      if (Enum.TryParse(roleName, true, out Role flag))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
  public class CustomPrincipalSerializeModel
  {
    public Guid Gid { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    public virtual Role Role { get; set; }

    /// <summary>
    /// 生理性別
    /// </summary>
    public Sex Sex { get; set; }

    /// <summary>
    /// 暱稱
    /// </summary>
    public string NickName { get; set; }

    /// <summary>
    /// 行動電話號碼
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    /// 電子信箱
    /// </summary>
    public string Email { get; set; }
  }
}
