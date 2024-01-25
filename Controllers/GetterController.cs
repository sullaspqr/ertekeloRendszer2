using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using ertekeloRendszer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ertekeloRendszer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetterController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new ErtekeloRendszerContext())
            {
                try
                {
                    return Ok(context.Getters.ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpGet("{nev}")]
        public IActionResult Get(string nev)
        {
            using (var context = new ErtekeloRendszerContext())
            {
                try
                {
                    return Ok(context.Getters.Where(v => v.Nev == nev).ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
