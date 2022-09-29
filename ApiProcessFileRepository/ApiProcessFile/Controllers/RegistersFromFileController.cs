using ApiProcessFile.Interfaces;
using ApiProcessFile.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProcessFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersFromFileController : ControllerBase
    {
        private readonly IProcessFile _processFile;
        public RegistersFromFileController(IProcessFile processFsfdsfle)
        {
            _processFile = processFsfdsfle;
        }

        [HttpGet]
        public  void WriteRegisterFromFile(string ds)
        {
               _processFile.GetProcessFiles( ds);
        }
    }
}
