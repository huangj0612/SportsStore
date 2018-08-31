using SportsStore.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int pageSize = 4;//分页 每页显示个数

        public ProductController(IProductRepository productRepositoryParam)
        {
            this.repository = productRepositoryParam;
        }

        public ViewResult ShowList(int page = 1)//第几页
        {
            return View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize));
        }
    }
}