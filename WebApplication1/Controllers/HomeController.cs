using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Farkle.Models;


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
            
            
            FarkleModel.DiceRoll = FarkleModel.P.DiceRoll;
            setDiceImages();
            
            return View();
        }

       /* [HttpPost]
        public IActionResult Farkle()
        {
            return View();
        }*/

        
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

        public void setDiceImages()
        {
            for (int i = 0; i < FarkleModel.DiceRoll.Count; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (FarkleModel.DiceRoll[i] == j)
                    {
                        FarkleModel.DiceImg[i] = FarkleModel.DicePath[j - 1];
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