using CQRSandMediator.Application.Blogs.Queries.GetBlogById;
using CQRSandMediator.Application.Blogs.Queries.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CQRSandMediator.webapprazor.Pages
{
    public class DetailsModel : PageModelBase
    {
        [BindProperty]
        public BlogVm Blog { get; set; } = default!;
        public async Task<IActionResult> OnGet(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                Blog = blog;
            }
            return Page();
        }
    }
}
