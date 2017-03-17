using System.Web.Http;
using System.Web.Http.Results;
using eFoodShop.Application.Dto;
using eFoodShop.Application.Services.Interfaces;

namespace eFoodShop.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public JsonResult<ProductDto> Get(int id)
        {
            var productDto = _productService.Get(id);
            return Json(productDto);
        }

        public JsonResult<ProductDto> Post(ProductDto productDto)
        {
            _productService.Create(productDto);

            return Json(productDto);
        }
    }
}
