using Microsoft.AspNetCore.Mvc;
using NLog;
using RepoApp.Common;
using RepoApp.Common.DataTables;
using RepoApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace RepoApp.API.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly FirstContext _context;
        public BaseController(FirstContext context)
        {
            _context = context;
        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected virtual JsonResult CreateDataTableResult<RecordModelT>(IEnumerable<RecordModelT> records, DataTablesParameters parameters) where RecordModelT : class, new()
        {
            return Json(new DataTableJsonResponse<RecordModelT> { Draw = parameters.Draw, RecordsTotal = parameters.TotalCount, RecordsFiltered = parameters.TotalCount, Data = records });
        }
        protected IActionResult CreateJsonValidationError(Dictionary<string, string> valMessages)
        {
            ExecutionResult result = new ExecutionResult { ExecutionStatus = ResultOutcome.NOTVALID, ValidationMessages = valMessages };
            return Json(result);
        }

        protected JsonResult CreateJsonOk()
        {
            ExecutionResult result = new ExecutionResult { ExecutionStatus = ResultOutcome.OK };
            return Json(result);
        }

        protected IActionResult CreateExceptionLog(Exception exception, string ErrorMessage = "")
        {
            logger.Error(exception, "Custom CreateException (Base API Contoller");

            return BadRequest();
        }




    }
}
