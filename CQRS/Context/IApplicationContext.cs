using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Context
{
    public interface IApplicationContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChangesAsync();
    }
}
