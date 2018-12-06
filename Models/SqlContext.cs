using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using secapi.Models;

namespace secapi.Models
{
    public class SqlContext: DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Bucket> Bucket { get; set; }
        public virtual DbSet<vBucket> vBucket { get; set; }
    }
}