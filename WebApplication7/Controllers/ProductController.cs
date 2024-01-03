using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication7.Data;
using WebApplication7.Entities;
using WebApplication7.Extensions;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        int _pageSize;
        private ILogger _logger;

        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo)
        {
            var groupMame = group.HasValue? _context.DishGroups.Find(group.Value)?.GroupName: "all groups";
            _logger.LogInformation($"info: group={group}, page={pageNo}");

            var dishesFiltered = _context.Dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            ViewData["Groups"] = _context.DishGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }


    }
}