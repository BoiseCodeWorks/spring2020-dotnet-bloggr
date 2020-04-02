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
    public class TagsController : ControllerBase
    {
        private readonly TagsService _service;
        private readonly BlogsService _bs;
        public TagsController(TagsService ts, BlogsService bs)
        {
            _service = ts;
            _bs = bs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tag>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // api/Tags/:TagId/blogs
        [HttpGet("{id}/blogs")]
        public ActionResult<IEnumerable<BlogTagViewModel>> GetBlogsByTagId(int id)
        {
            try
            {
                return Ok(_bs.GetBlogsByTagId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Tag> Create([FromBody] Tag newTag)
        {
            try
            {
                return Ok(_service.Create(newTag));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}