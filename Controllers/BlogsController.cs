using System;
using System.Collections.Generic;
using bloggr.Models;
using bloggr.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bloggr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsService _bs;
        public BlogsController(BlogsService bs)
        {
            _bs = bs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            try
            {
                return Ok(_bs.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Blog> Create([FromBody] Blog newBlog)
        {
            try
            {
                // req.user.sub || req.userInfo.sub
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                newBlog.AuthorId = userId;
                return Ok(_bs.Create(newBlog));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}