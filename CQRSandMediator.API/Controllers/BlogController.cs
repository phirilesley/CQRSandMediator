using CQRSandMediator.Application.Blogs.Commands.CreateBlog;
using CQRSandMediator.Application.Blogs.Commands.DeleteBlog;
using CQRSandMediator.Application.Blogs.Commands.UpdateBlog;
using CQRSandMediator.Application.Blogs.Queries.GetBlogById;
using CQRSandMediator.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSandMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var createdBlog = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

           await Mediator.Send(command);

           return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await Mediator.Send(new DeleteBlogCommand { Id = id });
            if(result ==0)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
