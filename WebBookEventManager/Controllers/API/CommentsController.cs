using Entities.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Entities.Models;
using DTO.Events;
using AutoMapper;
using DTO.Comment;

namespace WebBookEventManager.Controllers.API
{
    public class CommentsController : ApiController
    {
        UnitOfWork _context;
        public CommentsController()
        {
            _context = new UnitOfWork();
        }

        // GET /api/comment/1
        public IHttpActionResult GetComments(int id)
        {
            var comments = _context.Comments
                            .Find(m => m.EventId == id)
                            .Select(m =>
                            {
                                return new CommentDto()
                                {
                                    Comment = m.Content,
                                    Id = m.Id,
                                    EventId = id,
                                };
                            });
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);
        }

        // POST /api/comments
        [HttpPost]
        public IHttpActionResult CreateComment(int id, CommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var comment = Mapper.Map<CommentDto, Comment>(commentDto);
            comment.EventId = id;
            _context.Comments.Add(comment);
            _context.Complete();
            return Created(new Uri(Request.RequestUri + "/" + id), comment);
        }

        // PUT /api/Comment/1
        [HttpPut]
        public IHttpActionResult UpdateComment(int id, CommentDto CommentDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var CommentInDB = _context.Comments.Find(c => c.Id == id);
            if (CommentInDB == null)
            {
                NotFound();
            }
            Mapper.Map(CommentDto, CommentInDB);
            _context.Complete();
            return Ok();
        }

        // DELETE /api/Comments/1
        [HttpDelete]
        public void DeleteComment(int id)
        {
            var CommentInDB = _context.Comments.Get(id);
            if (CommentInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Comments.Remove(CommentInDB);
            _context.Complete();
        }
    }
}
