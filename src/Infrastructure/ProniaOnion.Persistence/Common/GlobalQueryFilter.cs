using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Common
{
    public static class GlobalQueryFilter
    {
        public static void ApplyQuery<T>(ModelBuilder builder) where T:BaseEntity,new()
        {
            builder.Entity<T>().HasQueryFilter(x => x.IgnoreQuery == false);

        }
        public static void ApplyQueryFilter(this ModelBuilder builder)
        {
            ApplyQuery <Category>(builder);
            ApplyQuery <Tag>(builder);
        }
    }
}
