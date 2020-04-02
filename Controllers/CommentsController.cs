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
    [Authorize]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _service;
        public CommentsController(CommentsService cs)
        {
            _service = cs;
        }

        [HttpPost]
        public ActionResult<Comment> Create([FromBody] Comment newComment)
        {
            try
            {
                // req.user.sub || req.userInfo.sub
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                newComment.AuthorId = userId;
                return Ok(_service.Create(newComment));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Comment> Edit(int id, [FromBody] Comment updatedComment)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                updatedComment.AuthorId = userId;
                updatedComment.Id = id;
                return Ok(_service.Edit(updatedComment));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<Comment> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                return Ok(_service.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}