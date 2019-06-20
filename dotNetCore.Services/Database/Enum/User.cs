using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetCore.Services.Database.Enum
{
  /// <summary>
  /// 生理性別
  /// </summary>
  public enum Sex
  {
    /// <summary>
    /// 未知
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// 男性
    /// </summary>
    Male = 1,
    /// <summary>
    /// 女性
    /// </summary>
    Female = 2,
    /// <summary>
    /// 其他
    /// </summary>
    Other = 3
  }

  /// <summary>
  /// 角色權限
  /// </summary>
  public enum Role
  {
    /// <summary>
    /// 一般使用者
    /// </summary>
    User = 0,
    /// <summary>
    /// 後台管理者
    /// </summary>
    BackAdmin = 1,
    /// <summary>
    /// 系統管理者
    /// </summary>
    SysAdmin = 2,
  }

  /// <summary>
  /// 角色狀態
  /// </summary>
  public enum Status
  {
    /// <summary>
    /// 封鎖
    /// </summary>
    Block = 0,
    /// <summary>
    /// 啟用
    /// </summary>
    Enable = 1
  }
}
