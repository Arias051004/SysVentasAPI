
using BusinessLogic.ProductsByBills;
using BusinessLogicInterface.ProductsByBills;
using EntitiesInterface.Helpers.Communication;
using Microsoft.AspNetCore.Mvc;

namespace SysVentasAPI.Controllers.ProductsByBills
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsByBillController : ControllerBase
    {
        private readonly IProductsByBillBL _ProductsByBillBL;

        public ProductsByBillController()
        {
            _ProductsByBillBL = new ProductsByBillBL();
        }

        [HttpGet]
        [Route("GetAll")]
        public IResponse GetAll(string filter)
        {
            return _ProductsByBillBL.GetAll(filter);
        }

        [HttpGet]
        public IResponse Get(int id)
        {
            return _ProductsByBillBL.Get(id);
        }

        [HttpPost]
        public IResponse Save(string productsByBill)
        {
            return _ProductsByBillBL.Save(productsByBill);
        }

        [HttpPut]
        public IResponse Update(string productsByBill)
        {
            return _ProductsByBillBL.Update(productsByBill);
        }

        [HttpDelete]
        public IResponse Delete(int id)
        {
            return _ProductsByBillBL.Delete(id);
        }
    }
}
