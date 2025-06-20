using SC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Repositories
{
    public interface IContactoRepository
    {
        Task<IEnumerable<Contacto>> GetAllAsync();
        Task<Contacto?> GetByIdAsync(int id);
        Task AddAsync(Contacto contacto);
        Task UpdateAsync(Contacto contacto);
        Task DeleteAsync(int id);
    }
}
