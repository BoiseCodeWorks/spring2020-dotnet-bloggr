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
    public class BlogTagsController : ControllerBase
    {
        private readonly BlogTagsService _service;
        private readonly BlogsService _bs;
        public BlogTagsController(BlogTagsService ts, BlogsService bs)
        {
            _service = ts;
            _bs = bs;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<BlogTag> Create([FromBody] BlogTag newBlogTag)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newBlogTag.AuthorId = userId;
                return Ok(_service.Create(newBlogTag));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<BlogTag> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_service.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}