using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Farkle.Models;
using Farkle;


namespace Farkle.Controllers
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

        public IActionResult Farkle()
        {

            var model = new FarkleModel();
            //FarkleModel.DiceRoll = FarkleModel.P.DiceRoll;
            model.DiceRoll.AddRange(new[] { 1, 2, 3, 4, 5, 6, });

            for (int i = 0; i < model.DiceRoll.Count; i++)
            {
                int val = model.DiceRoll[i];
                model.DiceImg[i] = model.DicePath[val - 1];

            }
            setDiceImages(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Roll()
        {
            var model = new FarkleModel();

            var roller = new Dice();
            model.DiceRoll = roller.DiceRoll;
            for (int i = 0; i < model.DiceRoll.Count; i++)
            {
                int val = model.DiceRoll[i];
                model.DiceImg[i] = model.DicePath[val - 1];

            }
            return View("Farkle", model);
        }


        /* public void Roll()
         {
             Player p = new Player();
             *//*if (fm != null)
             {*/
        /*fm.DiceRoll = p.DiceRoll;*/

        /*pm.intDie1 = P.DiceRoll[1];
        pm.intDie2 = P.DiceRoll[2];
        pm.intDie3 = P.DiceRoll[3];
        pm.intDie4 = P.DiceRoll[4];
        pm.intDie5 = P.DiceRoll[5];
        pm.intDie6 = P.DiceRoll[6];*/

        /*}*/
        /*Farkle();*//*
    }
*/
        public IActionResult Rules()
        {
            return View();
        }

        public IActionResult LeaderBoard()
        {
            return View();
        }

        public void setDiceImages(FarkleModel model)
        {
            for (int i = 0; i < model.DiceRoll.Count; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (model.DiceRoll[i] == j)
                    {
                        model.DiceImg[i] = model.DicePath[j - 1];
                    }
                }
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}