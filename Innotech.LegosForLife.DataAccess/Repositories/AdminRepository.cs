using System.Collections.Generic;
using System.IO;
using System.Linq;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;

namespace InnoTech.LegosForLife.DataAccess.Repositories
{
    public class AdminRepository:IAdminRepository
    {
        private readonly MainDbContext _ctx;

        public AdminRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Admin Repository Must have a DBContext");
            _ctx = ctx;
        }

        public List<Admin> FindAll()
        {
            return _ctx.Admins
                .Select(ae => new Admin()
            {
                Id = ae.Id,
                Name = ae.Name
            }).ToList();
        }
    }
}