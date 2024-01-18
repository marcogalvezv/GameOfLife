using GameOfLife.Models;
using GameOfLife.Orchestrators;
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
        BoardOrchestrator boardOrchestrator = new BoardOrchestrator(3,3);
        // GET: BoardController
        //[HttpGet]
        //public string GetBoard()
        //{
        //    return JsonConvert.SerializeObject(boardOrchestrator.CurrentBoard);
        //    //Board board = new Board(3, 3);
        //    //board.InitRandomBoard();
        //    //board.EvaluateBoard();
        //    //var t = JsonConvert.SerializeObject(board);
        //    //return t;
        //}


        [HttpGet]      
        public string GetBoardState(int index)
        {
            return JsonConvert.SerializeObject(boardOrchestrator.GetState(index));            
        }

        [HttpPost(Name = "PostBoard")]
        public string PostBoard(String board)
        {
 
            Board postedBoard = JsonConvert.DeserializeObject<Board>(board);
            boardOrchestrator.CurrentBoard=postedBoard;
            boardOrchestrator.Evaluate();
            var t = JsonConvert.SerializeObject(boardOrchestrator.CurrentBoard);
            return t;
        }

        //[HttpGet(Name = "Evaluate")]
        //public string Evaluate()
        //{
        //    boardOrchestrator.Evaluate();
        //     var t = JsonConvert.SerializeObject(boardOrchestrator.CurrentBoard);
        //    return t;
        //}



    }
}
