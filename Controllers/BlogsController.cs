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

        [HttpGet("myBlogs")]  // api/blogs/myblogs
        [Authorize]
        public ActionResult<IEnumerable<Blog>> GetUserBlogs()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_bs.GetUserBlogs(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            try
            {
                // get the blog
                Blog blog = _bs.Get(id);
                if (blog.IsPrivate)
                {
                    //if the user logged in
                    //Check if user has a claim
                    var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                    //if logged in user is author
                    if (user != null && user.Value == blog.AuthorId)
                    {
                        // return blog
                        return Ok(blog);
                    }
                    return Unauthorized("You do not have acces to this blog");
                }
                return Ok(blog);
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

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Blog> Edit(int id, [FromBody] Blog updatedBlog)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                updatedBlog.AuthorId = userId;
                updatedBlog.Id = id;
                return Ok(_bs.Edit(updatedBlog));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Blog> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                return Ok(_bs.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}