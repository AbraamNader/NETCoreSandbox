using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreSandbox.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Data> Data { get; set; }
    }
    public class Data
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }
    }

    public class Language
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }
    }

    public class Translation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long LanguageId { get; set; }
        public long DataId { get; set; }

        public virtual Language Language { get; set; }

        public virtual Data Data { get; set; }
    }
}
