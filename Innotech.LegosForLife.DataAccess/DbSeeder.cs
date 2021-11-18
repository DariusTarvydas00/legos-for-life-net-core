using System.Linq;
using InnoTech.LegosForLife.DataAccess.Entities;

namespace InnoTech.LegosForLife.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDbContext _ctx;

        public DbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.Products.Add(new ProductEntity{Name = "Lego1"});
            _ctx.Products.Add(new ProductEntity{Name = "Lego2"});
            _ctx.Products.Add(new ProductEntity{Name = "Lego3"});
            _ctx.Users.Add(new UserEntity{Name = "User1"});
            _ctx.Users.Add(new UserEntity{Name = "User2"});
            _ctx.Users.Add(new UserEntity{Name = "User3"});
            _ctx.Admins.Add(new AdminEntity{Name = "Admin1"});
            _ctx.Admins.Add(new AdminEntity{Name = "Admin2"});
            _ctx.Admins.Add(new AdminEntity{Name = "Admin3"});
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
            var countP = _ctx.Products.Count();
            var countU = _ctx.Users.Count();
            var countA = _ctx.Admins.Count();
            if (countP == 0)
            {
                _ctx.Products.Add(new ProductEntity{Name = "Lego1"});
                _ctx.Products.Add(new ProductEntity{Name = "Lego2"});
                _ctx.Products.Add(new ProductEntity{Name = "Lego3"});
                _ctx.SaveChanges();
            }

            if (countU == 0)
            {
                _ctx.Users.Add(new UserEntity{Name = "User1"});
                _ctx.Users.Add(new UserEntity{Name = "User2"});
                _ctx.Users.Add(new UserEntity{Name = "User3"});
            }

            if (countA == 0)
            {
                _ctx.Admins.Add(new AdminEntity{Name = "Admin1"});
                _ctx.Admins.Add(new AdminEntity{Name = "Admin2"});
                _ctx.Admins.Add(new AdminEntity{Name = "Admin3"});
            }

        }
    }
}