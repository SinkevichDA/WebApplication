using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication7.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication7.Controllers
{
    
        public class HomeController : Controller
        {
            private List<ListDemo> _listDemo;
            public IActionResult Index()
            {
                ViewData["Text"] = "Лабораторная работа 2";
                ViewData["Lst"] =
                new SelectList(_listDemo, "ListItemValue", "ListItemText");
                return View();
            }
            public HomeController()
            {
                _listDemo = new List<ListDemo>
        {
        new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
        new ListDemo{ ListItemValue=2, ListItemText="Item 2"},
        new ListDemo{ ListItemValue=3, ListItemText="Item 3"}
        };


            }
            public class ListDemo
            {

                public int ListItemValue { get; set; }
                public string? ListItemText { get; set; }


            }

        }


    }
