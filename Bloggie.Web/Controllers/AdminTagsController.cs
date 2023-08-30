using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {

        // Also construction.
        private readonly BloggieDbContext bloggieDbContext;

        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        /*
        // Below code representing the contruction of code, which can run in HTTPPOST.
        private BloggieDbContext _bloggieDbContext;
        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;   
        }
        */

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //Below comment code testing purpose(Want to data coming from controller)
            //var name = Request.Form["name"];
            //var displayName = Request.Form["displayName"];

            //Below comment code testing purpose(Want to data coming from controller via class)
            //var name = addTagRequest.Name;
            //var displayName = addTagRequest.DisplayName;


            //Mapping AddTagRequest to Tag domin model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            bloggieDbContext.Tags.Add(tag);
            bloggieDbContext.SaveChanges();

            return View("Add");
        }

    }
}
