using dotNetCore.Services.Database.Entity;
using dotNetCore.Services.Database.Models;
using dotNetCore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace dotNetCore.Services.Services
{
  public class UserService : EntityService<User>, IUserService
  {
    private readonly Database.Entity.EntityDbContext _db;

    public UserService(Database.Entity.EntityDbContext db) : base(db)
    {
      this._db = db;
      _dbSet = this._db.Set<User>();
    }

    public async Task<User> LoginAsync(string account, string password)
    {
      return await _dbSet.FirstOrDefaultAsync(x => x.Account.Equals(account, StringComparison.CurrentCultureIgnoreCase) && x.Password.Equals(password));
    }

    
  }
}
