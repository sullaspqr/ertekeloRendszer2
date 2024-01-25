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
    public class ScreeningController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new ErtekeloRendszerContext())
            {
                try
                {
                    return Ok(context.Screenings.ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
