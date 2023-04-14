
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using SubIn.Models;

namespace SubIn.Controllers
{
    public class ItemController : Controller
    {
        // GET: ItemController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:44313/api/ApiItems/";

            using (HttpClient client = new HttpClient())
            {
                // Realiza una solicitud GET a la API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Verifica si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta como una lista de objetos
                    List<Item> items = await response.Content.ReadAsAsync<List<Item>>();

                    return View(items);
                }
                else
                {
                    return View("Error");
                }
            }
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View(new Item());
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Item itemcito)
        {
            // Crear una instancia de HttpClient
            using (var httpClient = new HttpClient())
            {
                // URL de tu API
                string apiUrl = "https://localhost:44313/api/ApiItems";

                // Crear un objeto de datos
                Item datos = new Item
                {
                    id_item = itemcito.id_item,
                    nombre_item = itemcito.nombre_item,
                    descripcion_item = itemcito.descripcion_item,
                    id_categoria = itemcito.id_categoria
                };

                // Convertir el objeto de datos a JSON
                string json = JsonConvert.SerializeObject(datos);

                // Crear el contenido de la solicitud con el JSON como contenido
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                // Hacer la solicitud HTTP POST a la API
                HttpResponseMessage respuesta = await httpClient.PostAsync(apiUrl, contenido);

                // Verificar si la solicitud fue exitosa
                if (respuesta.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index"); // Redirigir
                }
                else
                {

                    return View("Error"); // Mostrar una vista de error 
                }
            }
           }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Item().ObtenerItemById(id));
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, Item itemcito)
        {
            try
            {
                itemcito.UpdateItem(itemcito);
                return View("Index", new Item().GetItem());
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View();
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Item().ObtenerItemById(id));
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection, Item itemcito)
        {
            try
            {
                itemcito.DeleteItem(itemcito); return View("Index");
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return View("Index");
            }
        }
    }
}
