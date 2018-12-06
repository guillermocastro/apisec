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
        public virtual DbSet<BucketType> BucketType { get; set; }
        public virtual DbSet<HourType> HourType { get; set; }
        public virtual DbSet<Hour> Hour { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<Edge> Edge { get; set; }
        public virtual DbSet<EdgeType> EdgeType { get; set; }
    }
}