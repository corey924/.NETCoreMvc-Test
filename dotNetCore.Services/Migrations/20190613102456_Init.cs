using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNetCore.Services.Migrations
{
  public partial class Init : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "User",
          columns: table => new
          {
            Gid = table.Column<Guid>(nullable: false),
            Account = table.Column<string>(maxLength: 20, nullable: false),
            Password = table.Column<string>(maxLength: 50, nullable: false),
            Enable = table.Column<int>(nullable: false, defaultValue: 0),
            Role = table.Column<int>(nullable: false, defaultValue: 0),
            Sex = table.Column<int>(nullable: false, defaultValue: 0),
            NickName = table.Column<string>(maxLength: 20, nullable: true),
            Mobile = table.Column<string>(maxLength: 20, nullable: true),
            Email = table.Column<string>(maxLength: 50, nullable: true),
            CreatedAt = table.Column<DateTime>(nullable: false),
            UpdatedAt = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_User", x => x.Gid);
            table.UniqueConstraint("UQ_Account", x => x.Account);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "User");
    }
  }
}
