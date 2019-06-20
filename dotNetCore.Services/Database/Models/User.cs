using dotNetCore.Services.Database.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Toolbelt.ComponentModel.DataAnnotations.Schema;

namespace dotNetCore.Services.Database.Models
{
  public class User
  {
    [Key]
    public Guid Gid { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    [Index]
    [Required]
    [MaxLength(20)]
    public string Account { get; set; }

    /// <summary>
    /// 密碼
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

    [Required]
    [DefaultValue(true)]
    public Status Enable { get; set; }

    /// <summary>
    /// 角色權限
    /// </summary>
    [Required]
    [DefaultValue(0)]
    public Role Role { get; set; }

    /// <summary>
    /// 生理性別
    /// </summary>
    [Required]
    [DefaultValue(0)]
    public Sex Sex { get; set; }

    /// <summary>
    /// 暱稱
    /// </summary>
    [MaxLength(20)]
    public string NickName { get; set; }

    /// <summary>
    /// 行動電話號碼
    /// </summary>
    [MaxLength(20)]
    public string Mobile { get; set; }

    /// <summary>
    /// 電子信箱
    /// </summary>
    [MaxLength(50)]
    public string Email { get; set; }

    /// <summary>
    /// 建立日期
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 最後修改日期
    /// </summary>
    public DateTime UpdatedAt { get; set; }
  }
}
