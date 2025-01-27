using BusinessLogic.Bills;
using BusinessLogicInterface.Bills;
using EntitiesInterface.Helpers.Communication;
using Microsoft.AspNetCore.Mvc;

namespace SysVentasAPI.Controllers.Bills
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillBL _BillBL;

        public BillController()
        {
            _BillBL = new BillBL();
        }

        [HttpGet]
        [Route("GetAll")]
        public IResponse GetAll(string filter)
        {
            return _BillBL.GetAll(filter);
        }

        [HttpGet]
        public IResponse Get(int id)
        {
            return _BillBL.Get(id);
        }

        [HttpPost]
        public IResponse Save(string bill)
        {
            return _BillBL.Save(bill);
        }

        [HttpPut]
        public IResponse Update(string bill)
        {
            return _BillBL.Update(bill);
        }

        [HttpDelete]
        public IResponse Delete(int id)
        {
            return _BillBL.Delete(id);
        }
    }
}
