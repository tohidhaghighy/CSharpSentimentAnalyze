using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MlSentimentFirst.Models;
using MlSentimentFirstML.Model;

namespace MlSentimentFirst.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string text="مقداری ندارد")
        {
            
            ViewData["text"] = text;
            return View();
        }


        public IActionResult Checkitem(string name)
        {
            string result = "مشخص نشده";
            var sampleData = new ModelInput()
            {
                Phrase = name,
            };
            var predictionResult = ConsumeModel.Predict(sampleData);
            if (predictionResult.Prediction == "0")
            {
                result = "منفی";
            }
            else if (predictionResult.Prediction == "1")
            {
                result = " منفی";
            }
            else if (predictionResult.Prediction == "2")
            {
                result = "خنثی";
            }
            else if (predictionResult.Prediction == "3")
            {
                result = "مثبت";
            }
            else if (predictionResult.Prediction == "4")
            {
                result = "مثبت";
            }
            ViewData["text"] = result;
            return RedirectToAction("Index","Home",new { text=result});
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
