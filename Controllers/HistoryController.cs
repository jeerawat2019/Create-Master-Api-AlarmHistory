using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using AspNotCoreMachineHistory.DataBase;
using AspNotCoreMachineHistory.Models;
using AspNotCoreMachineHistory.Repo.InfBase;

namespace Namespace
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class HistoryController : ControllerBase
    {
        ILogger<HistoryController> mLogger;

        public HistoryController(ILogger<HistoryController> logger, IHistory history)
        {
            mLogger = logger;
            mHistory = history;
        }
        public IHistory mHistory { get; }

        [HttpGet]//https://localhost:5001/history
        public ActionResult GetAllHistory()
        {
            try
            {
                return Ok(new { result = mHistory.GetHistory(), message = "request successfully" });
            }
            catch (Exception ex)
            {

                mLogger.LogError("Failed" + ex);
                return StatusCode(500, new { result = ex, message = ex });
            }
        }

        [HttpGet("{id}")]//https://localhost:5001/history/1
        public IActionResult GetHistory(int id)
        {
            try
            {
                var result = mHistory.GetHistoryById(id);

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new { result = result, message = "request successfully" });
                }
            }
            catch (Exception error)
            {
                mLogger.LogError($"Log GetHistoryById: {error}");
                return StatusCode(500, new { result = "", message = error });
            }
        }

        [HttpPost]
        public IActionResult NewHistory([FromForm] HistoryModel data)
        {
            try
            {
                var result = mHistory.AddHistory(data);
                return Ok(new { result = result, message = "create history successfully" });
            }
            catch (System.Exception ex)
            {

                mLogger.LogError($"Log CreateHistory:{ex}");
                return StatusCode(500, new { result = "", meassage = ex });
            }
        }
        [HttpPut("{id}")]
        public IActionResult EditHistory([FromForm] HistoryModel data, int id)
        {
            try
            {
                var result = mHistory.EditHistory(data, id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(new { result = result, message = "update history successfully" });
            }
            catch (Exception error)
            {
                mLogger.LogError($"Log UpdateProduct: {error}");
                return StatusCode(500, new { result = "", message = error });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHistory(int id)
        {
            try
            {
                var result = mHistory.DeleteHistory(id);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok(new { result = "", message = "delete history sucessfully" });
            }
            catch (Exception error)
            {
                mLogger.LogError($"Log DeleteProduct: {error}");
                return StatusCode(500, new { result = "", message = error });
            }
        }

    }
}