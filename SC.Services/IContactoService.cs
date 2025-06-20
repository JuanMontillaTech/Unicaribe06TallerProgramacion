using SC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Services
{
    public interface IContactoService
    {

        Task<IEnumerable<Contacto>> ObtenerTodosAsync();
        Task<Contacto?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Contacto contacto);
        Task ActualizarAsync(Contacto contacto);
        Task EliminarAsync(int id);
    }
}
