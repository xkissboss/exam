using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exam.Service.IQ;
using Exam.Models;

namespace Exam.Manage.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IIQService iIQService;

        public ValuesController(IIQService iIQService)
        {
            this.iIQService = iIQService;
        }



        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IQEntity iq = new IQEntity();
            iq.Context = "你大爷试试";
            iq.IType = 1;
            IQOption option1 = new IQOption();
            option1.Context = "选项1";

            IQOption option2 = new IQOption();
            option2.Context = "选项2";

            iq.OptionList.Add(option1);
            iq.OptionList.Add(option2);

            iIQService.Insert(iq);
            return new string[] { "value1", "" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
