using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

   

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    UnitOfWork uow= new UnitOfWork();
        //    uow.ProductRepository.Create(new Product { Id =1, Name = "Product 1", Price = 100 });
        //    uow.OrderRepository.Create(new Order { Id = 1, ProductId = 1, Quantity = 2 });
            
        //    uow.Save();
        //    return View();
        //} 
    }
}
