using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Entities;

namespace Data
{
    public class ApplicationDbContext
        (DbContextOptions<ApplicationDbContext>
        options) : DbContext(options)
    {

        public DbSet<Contacto> contactos =>   Set<Contacto>();
    }
}
