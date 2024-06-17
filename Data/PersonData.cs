using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TDBBaiThi2324.Models;

    public class PersonData : DbContext
    {
        public PersonData (DbContextOptions<PersonData> options)
            : base(options)
        {
        }

        public DbSet<TDBBaiThi2324.Models.TDB100Person> TDB100Person { get; set; } = default!;

public DbSet<TDBBaiThi2324.Models.TDB100Emmployee> TDB100Emmployee { get; set; } = default!;
    }
