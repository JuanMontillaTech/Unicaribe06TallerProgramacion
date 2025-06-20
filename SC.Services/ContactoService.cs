using SC.Entities;
using SC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Services
{
    public class ContactoService(IContactoRepository repository) : IContactoService
    {
        public async    Task ActualizarAsync(Contacto contacto)
         => await  repository.UpdateAsync(contacto);
         

        public async Task CrearAsync(Contacto contacto)
            => await  repository.AddAsync(contacto);
      

        public async Task EliminarAsync(int id)
        => await repository.DeleteAsync(id);

        public async Task<Contacto?> ObtenerPorIdAsync(int id)
        => await  repository.GetByIdAsync(id);

        

        public async Task<IEnumerable<Contacto>> ObtenerTodosAsync()
       =>      await  repository.GetAllAsync();
        
    }
}
