namespace dotNetCore.ViewModels
{
  public class LoginView
  {
    /// <summary>
    /// 帳號
    /// </summary>
    public string account { get; set; }
    /// <summary>
    /// 密碼
    /// </summary>
    public string password { get; set; }

    /// <summary>
    /// 導向網址
    /// </summary>
    public string returnUrl { get; set; }
  }
}
