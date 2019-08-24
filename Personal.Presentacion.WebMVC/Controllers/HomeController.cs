using Personal.Presentacion.WebMVC.Models;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personal.Presentacion.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Boleta()
        {
            var boleta = new Boleta()
            {
                Cliente = "Daniel Carbajal",
                FechaDeVenta = DateTime.Now,
                Serie = "B012-00000001",
                Total = 100,
                Detalles = new List<DetalleDeVenta>()
                {
                    new DetalleDeVenta() { Descripcion = "Tomate", Monto = 50},
                    new DetalleDeVenta() { Descripcion = "Cebolla", Monto = 50}
                }
            };
            boleta.CargarQR();
            return View(boleta);
        }

        public ActionResult pdf()
        {
            MemoryStream file = new MemoryStream();
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertUrl(@"http://localhost:50863/home/boleta");
            doc.Save(file);
            doc.Close();
            return File(file.ToArray(), "boleta.pdf");
        }
    

    }
}