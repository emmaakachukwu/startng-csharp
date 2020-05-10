﻿using System.Text.RegularExpressions;
using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using task4.Models;

namespace task4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firstNumber, string secondNumber)
        {
            int firstNum;
            int secondNum;
            double firstSqrt;
            double secondSqrt;
            string result = "";

            if ( int.TryParse(firstNumber, out _) && int.TryParse(secondNumber, out _) ) {
                firstNum = int.Parse(firstNumber);
                secondNum = int.Parse(secondNumber);

                if ( firstNum < 1 || secondNum < 1 ) {
                    result = "Negative numbers not allowed";
                } else {
                    firstSqrt = Math.Sqrt(firstNum);
                    secondSqrt = Math.Sqrt(secondNum);

                    if ( firstSqrt > secondSqrt ) {
                        result = "The number "+firstNum+" with square root "+firstSqrt+" has a higher square root than the number "+secondNum+" with square root "+secondSqrt;
                    } else if ( firstSqrt < secondSqrt ) {
                        result = "The number "+secondNum+" with square root "+secondSqrt+" has a higher square root than the number "+firstNum+" with square root "+firstSqrt;
                    } else if ( firstSqrt == secondSqrt ) {
                        result = "The number "+firstNum+" with square root "+firstSqrt+" has an equal square root with the number "+secondNum+". Enter another value";
                    }
                }                
            } else {
                result = "All values must be numbers";
            }

            ViewBag.Result = result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
