using BusinessLogic.Categories;
using BusinessLogicInterface.Categories;
using EntitiesInterface.Helpers.Communication;
using Microsoft.AspNetCore.Mvc;

namespace SysVentasAPI.Controllers.Categories
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryBL _CategoryBL;

        public CategoriesController()
        {
            _CategoryBL = new CategoryBL();
        }

        [HttpGet]
        [Route("GetAll")]
        public IResponse GetAll(string filter)
        {  
            return _CategoryBL.GetAll(filter);
        }

        [HttpGet]
        public IResponse Get(int id)
        {
            IResponse response = _CategoryBL.Get(id);
            HttpContext.Response.StatusCode = (int)response.Messages[response.Messages.Count - 1].MessageType;
            return response;
        }

        [HttpPost]
        public IResponse Save(string pCategory)
        {
            return _CategoryBL.Save(pCategory);
        }

        [HttpPut]
        public IResponse Update(string pCategory)
        {
            return _CategoryBL.Update(pCategory);
        }

        [HttpDelete]
        public IResponse Delete(int id)
        {
            return _CategoryBL.Delete(id);
        }
    }
}
