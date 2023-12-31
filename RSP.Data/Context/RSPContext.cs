    using Microsoft.EntityFrameworkCore;
    using RSP.Data.Entity;

    namespace RSP.Data.Context
    {
        public class RSPContext : DbContext
        {
            public RSPContext()
            {

            }

            public RSPContext(DbContextOptions<RSPContext> options) : base(options)
            {

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder builder)
            {

                //builder.Entity<User>(entity =>
                //{
                //    entity.HasKey(e => e.Id);
                //});

                builder.Entity<Reservation>(entity =>
                {
                    entity.HasKey(e => e.Id);
                });
            }
            //public DbSet<User> Users { get; set; }
            public DbSet<Reservation> Reservations { get; set; }
        }
    }
