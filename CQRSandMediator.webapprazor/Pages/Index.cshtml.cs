﻿using CQRSandMediator.Application.Blogs.Queries.GetBlogById;
using CQRSandMediator.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CQRSandMediator.webapprazor.Pages
{
    public class IndexModel : PageModelBase
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IList<BlogVm> Blog { get; set; }
        public async void OnGet()
        {
           var blogs = await Mediator.Send(new GetBlogQuery());
            Blog = blogs.ToList();
        }
    }
}
