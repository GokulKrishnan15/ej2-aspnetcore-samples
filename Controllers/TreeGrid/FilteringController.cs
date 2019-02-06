﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class TreeGridController : Controller
    {
       
        public IActionResult Filtering()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            ViewBag.dropdata = new List<object>() {
               new { id= "Parent", mode= "Parent" },
               new { id= "Child", mode= "Child" },
               new { id= "Both", mode= "Both" },
               new { id= "None", mode= "None" },
            };
            return View();
        }       
    }
}