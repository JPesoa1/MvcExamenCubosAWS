using Microsoft.AspNetCore.Mvc;
using MvcExamenCubosAWS.Models;
using MvcExamenCubosAWS.Repositories;

namespace MvcExamenCubosAWS.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubo repo;

        public CubosController(RepositoryCubo repo)
        {
            this.repo = repo;
        }



        public async Task<IActionResult> Index()
        {
            List<Cubo> cubos = await this.repo.GetCubos();

            return View(cubos);
        }




        public async Task<IActionResult> Details(int id)
        {
            Cubo cubo = await this.repo.FindCubo(id);

            return View(cubo);
        }


        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteCubos(id);

            return RedirectToAction("Index");
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cubo cubo)
        {
            await this.repo.InsertarCubo(cubo.nombre,cubo.marca,cubo.imagen,cubo.Precio);

            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Update(int id)
        {
            Cubo cubo = await this.repo.FindCubo(id);
            return View(cubo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Cubo cubo)
        {
            await this.repo.UpdateCubo(cubo.IdCubo,cubo.nombre, cubo.marca, cubo.imagen, cubo.Precio);

            return RedirectToAction("Index");
        }
    }
}
