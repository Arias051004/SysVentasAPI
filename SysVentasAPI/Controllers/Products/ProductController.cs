using BusinessLogic;
using BusinessLogic.Products;
using BusinessLogicInterface.Products;
using EntitiesInterface.Helpers.Communication;
using Microsoft.AspNetCore.Mvc;

namespace SysVentasAPI.Controllers.Products
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL _productBL;

        public ProductController() 
        {
            _productBL = new ProductBL();
        }

        [HttpGet]
        [Route("GetAll")]
        public IResponse GetAll(string filter)
        {
            return _productBL.GetAll(filter);
        }

        [HttpGet]
        public IResponse Get(int id)
        {
            return _productBL.Get(id);
        }

        [HttpPost]
        public IResponse Save(string pProduct)
        {
            return _productBL.Save(pProduct);
        }

        [HttpPut]
        public IResponse Update(string pProduct)
        {
            return _productBL.Update(pProduct);
        }

        [HttpDelete]
        public IResponse Delete(int id)
        {
            return _productBL.Delete(id);
        }
    }
}
