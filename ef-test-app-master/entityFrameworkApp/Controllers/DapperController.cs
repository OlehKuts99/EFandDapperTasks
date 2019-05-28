using System.Collections.Generic;
using DapperPersistence;
using DapperPersistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace entityFrameworkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        private readonly IDapperService _dapperService;

        public DapperController(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        [HttpGet]
        [Route("GetFirst")]
        public ActionResult<string> Get()
        {
            var customer = _dapperService.GetTopOneCustomer();
            return customer.Name;
        }

        [HttpGet]
        [Route("TaskOne")]
        public ActionResult<string> TaskOne([FromBody] string customerId)
        {
            var result = _dapperService.TaskOne(int.Parse(customerId));

            return result;
        }

        [HttpPost]
        [Route("TaskTwo")]
        public void TaskTwo([FromBody] TaskThreeSubtaskTwoModel model)
        {
            _dapperService.TaskTwo(model);
        }

        [HttpGet]
        [Route("TaskFour")]
        public List<string> TaskFour()
        {
            var result =_dapperService.TaskFour();

            return result;
        }

        [HttpGet]
        [Route("TaskFive")]
        public List<string> TaskFive()
        {
            var result = _dapperService.TaskFive();

            return result;
        }
    }
}