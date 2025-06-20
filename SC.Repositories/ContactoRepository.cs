using Data;
using Microsoft.EntityFrameworkCore;
using SC.Entities;


namespace SC.Repositories
{
    public class ContactoRepository(ApplicationDbContext context) : IContactoRepository
    {
        public async Task AddAsync(Contacto contacto)
        {
           await context.contactos.AddAsync(contacto);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var contacto = await context.contactos.FindAsync(id);
            if (contacto is not null)
            {
                context.contactos.Remove(contacto);
                await context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Contacto>> GetAllAsync()
        {
         return  await context.contactos.ToListAsync();
        }
        public Task<Contacto?> GetByIdAsync(int id)
        {
            return context.contactos.Where(x=> x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Contacto contacto)
        {
             context.contactos.Update(contacto);
            await context.SaveChangesAsync();
        }
    }
}
