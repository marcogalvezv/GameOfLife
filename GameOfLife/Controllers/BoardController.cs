using GameOfLife.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;


namespace GameOfLife.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : Controller
    {
        // GET: BoardController
        [HttpGet(Name = "GetBoard")]
        public string GetBoard()
        {
            Board board = new Board(3, 3);
            board.InitRandomBoard();
            board.EvaluateBoard();
            var t = JsonConvert.SerializeObject(board);
            return t;
        }

        [HttpPost(Name = "PostBoard")]
        public string PostBoard(String board)
        {
 
            Board postedBoard = JsonConvert.DeserializeObject<Board>(board);
            postedBoard.EvaluateBoard();
            var t = JsonConvert.SerializeObject(board);
            return t;
        }


       
    }
}
