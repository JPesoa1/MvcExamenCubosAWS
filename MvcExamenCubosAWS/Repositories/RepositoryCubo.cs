using Microsoft.EntityFrameworkCore;
using MvcExamenCubosAWS.Data;
using MvcExamenCubosAWS.Models;

namespace MvcExamenCubosAWS.Repositories
{
    public class RepositoryCubo
    {
        private CubosContext context;

        public RepositoryCubo(CubosContext context)
        {
            this.context = context;
        }

        private int GetMaxId()
        {
            return this.context.Cubos.Max(x => x.IdCubo) + 1;
        }

        public async Task InsertarCubo
            (string nombre , string marca , string imagen , int precio)
        {
            Cubo cubo = new Cubo();
            cubo.IdCubo = GetMaxId();
            cubo.nombre = nombre;
            cubo.marca = marca;
            cubo.imagen = imagen;
            cubo.Precio = precio;

            await this.context.Cubos.AddAsync(cubo);
            await this.context.SaveChangesAsync();
        }


        public async Task<List<Cubo>> GetCubos()
        {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<Cubo> FindCubo(int id)
        {
            return await this.context.Cubos.FirstOrDefaultAsync(x => x.IdCubo == id);
        }

        public async Task DeleteCubos(int id) 
        {
            Cubo cubo = await this.FindCubo(id);
            this.context.Remove(cubo);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCubo
              (int id ,string nombre, string marca, string imagen, int precio)
        {

            Cubo cubo = await this.FindCubo(id);
            cubo.nombre = nombre;
            cubo.marca = marca;
            cubo.imagen = imagen;
            cubo.Precio = precio;

            this.context.Cubos.Attach(cubo);
            await this.context.SaveChangesAsync();

        }

    }
}
