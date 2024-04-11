using Casino_V3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Linq;
using Casino_V3.Database;

namespace Casino_V3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Databaseconnection _db;

        public HomeController(ILogger<HomeController> logger, Databaseconnection db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        /* public IActionResult Roulette() 
         {
             return View();
         }*/
        public IActionResult Bar()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        
        private string connectionString = "Your_Connection_String_Here";

        
        // Kode som er skrevet herunder blev skrevet med hjælp fra ChatGPT da vi Chris og Andreas ikke kunne finde helt ud af hvordan man skulle sætte en roulette op
        // GET: /Roulette/Index
        public ActionResult Roulette()
        {
            int result = SpinRouletteWheel();
            ViewBag.Result = result;
            return View();
        }

        

        // POST: /Roulette/Spin
        [HttpPost]
        public ActionResult Spin()
        {
            int result = SpinRouletteWheel();
            SaveSpinResultToDatabase(result); // Save the spin result to the database
            return RedirectToAction("Roulette");
        }

        // POST: /Roulette/PlaceBet
        [HttpPost]
        public ActionResult PlaceBet(int betNumber)
        {
            string playerName = "Player1"; // Change to actual player name
            decimal betAmount = 10; // Change to actual bet amount
            //PlaceBetInDatabase(playerName, "Number", betAmount, betNumber); // Place the bet in the database
            return RedirectToAction("Roulette");
        }

        // Function to spin the roulette wheel and return the result
        private int SpinRouletteWheel()
        {
            Random random = new Random();
            return random.Next(0, 37); // Assuming numbers 0-36 for simplicity
        }

        // Function to save the spin result to the database
        private void SaveSpinResultToDatabase(int result)
        {
            _db.createSpinResult(result);
            
        }

        // Function to place a bet in the database
        /*private void PlaceBetInDatabase(string playerName, string betType, decimal amount, int betNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO Bets (PlayerName, BetType, BetNumber, Amount) VALUES (@PlayerName, @BetType, @BetNumber, @Amount)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlayerName", playerName);
                command.Parameters.AddWithValue("@BetType", betType);
                command.Parameters.AddWithValue("@BetNumber", betNumber);
                command.Parameters.AddWithValue("@Amount", amount);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        */
    }
}