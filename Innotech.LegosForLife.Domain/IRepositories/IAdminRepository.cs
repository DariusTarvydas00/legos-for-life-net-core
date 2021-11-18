﻿using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Domain.IRepositories
{
    public interface IAdminRepository
    {
        List<Admin> FindAll();
        Admin GetAdminById(int Id);
    }
}