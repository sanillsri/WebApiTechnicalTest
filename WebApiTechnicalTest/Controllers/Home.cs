﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTechnicalTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Web API Technical Test  ";
        }
    }
}
