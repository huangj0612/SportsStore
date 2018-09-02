using SportsStore.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

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

        //public ViewResult ShowList(int page = 1)//第几页
        //{
        //    return View(repository.Products
        //        .OrderBy(p => p.ProductID)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize));
        //}
        //public ViewResult ShowList(int page = 1)
        //{
        //    ProductsListViewModel model = new ProductsListViewModel
        //    {
        //        Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * pageSize).Take(pageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = pageSize,
        //            TotalItems = repository.Products.Count()
        //        }
        //    };
        //    return View(model);
        //}

        public ViewResult ShowList(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)//添加产品分类
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Products.Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}