using Microsoft.AspNetCore.Mvc;
using NLog;
using RepoApp.Common;
using RepoApp.Common.DataTables;
using RepoApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using static RepoApp.Common.EnumsCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RepoApp.Controllers
{
    public class BaseController : Controller
    {
        private IViewRenderService _viewRenderService;
        protected IViewRenderService ViewRenderService => _viewRenderService ??= HttpContext.RequestServices.GetService<IViewRenderService>();
        protected readonly FirstContext _context;
        public BaseController(FirstContext context)
        {
            _context = context;
        }
        protected string _WebServiceUrl
        {
            get
            {
                //return Request.Url.Scheme + "://" + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
                return string.Format("{0}://{1}:",
                       HttpContext.Request.Scheme, HttpContext.Request.Host, HttpContext.Connection.LocalPort);
            }
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected ViewResult CreateExceptionView(Exception exception)
        {
            logger.Error(exception, "Custom CreateExceptionView Exception (BaseController)");

            ViewBag.Message = exception.Message;
            return View("~/Views/Shared/Error.cshtml");

        }


        protected virtual JsonResult CreateDataTableResult<RecordModelT>(IEnumerable<RecordModelT> records, DataTablesParameters parameters) where RecordModelT : class, new()
        {
            return Json(new DataTableJsonResponse<RecordModelT> { Draw = parameters.Draw, RecordsTotal = parameters.TotalCount, RecordsFiltered = parameters.TotalCount, Data = records });
        }

        protected virtual IActionResult CreateDataTableError(string message)
        {
            return Json(new DataTableJsonResponse<string> { Draw = 0, RecordsTotal = 0, RecordsFiltered = 0, Data = Array.Empty<string>(), Error = message });
        }

        protected virtual IActionResult CreateJsonOk(string message = null, bool showToast = false)
        {
            return Json(new BaseJsonResponse { Result = ExecutionResultCore.OK, Message = message, ShowToast = showToast });
        }

        protected virtual IActionResult CreateJsonOk<RecordModelT>(RecordModelT record, string message = null, bool showToast = false) where RecordModelT : class
        {
            return Json(new SingleJsonResponse<RecordModelT> { Result = ExecutionResultCore.OK, Message = message, ShowToast = showToast, Record = record });
        }

        protected virtual IActionResult CreateJsonOk<RecordModelT>(IEnumerable<RecordModelT> records, string message = null, bool showToast = false) where RecordModelT : class
        {
            return Json(new CollectionJsonResponse<RecordModelT> { Result = ExecutionResultCore.OK, Message = message, ShowToast = showToast, Records = records });
        }

        protected virtual IActionResult CreateJsonOk<RecordModelT>(ICollection<RecordModelT> records, string message = null, bool showToast = false) where RecordModelT : class
        {
            return Json(new CollectionJsonResponse<RecordModelT> { Result = ExecutionResultCore.OK, Message = message, ShowToast = showToast, Records = records });
        }

        protected virtual IActionResult CreateJsonOk<RecordModelT>(List<RecordModelT> records, string message = null, bool showToast = false) where RecordModelT : class
        {
            return Json(new CollectionJsonResponse<RecordModelT> { Result = ExecutionResultCore.OK, Message = message, ShowToast = showToast, Records = records });
        }

        protected virtual IActionResult CreateJsonKo(string message = null)
        {
            return Json(new BaseJsonResponse { Result = ExecutionResultCore.KO, Message = message });
        }

        protected virtual IActionResult CreateJsonError(string message = null)
        {
            return Json(new BaseJsonResponse { Result = ExecutionResultCore.ERROR, Message = message });
        }

        protected virtual IActionResult CreateJsonException(Exception exception)
        {
            return Json(new ExceptionJsonResponse { Message = exception.Message, StackTrace = exception.StackTrace });
        }

        protected virtual async Task<IActionResult> CreateJsonResultViewAsync(string viewName, object model = null, ModelStateDictionary modelStateDictionary = null, ExpandoObject viewBag = null)
        {
            if (string.IsNullOrWhiteSpace(viewName))
            {
                return Json(new ViewResultJsonResponse { Result = ExecutionResultCore.OK, ViewHtml = string.Empty });
            }

            string viewHtml = await ViewRenderService.RenderToString(viewName, model, modelStateDictionary, viewBag);
            return Json(new ViewResultJsonResponse { Result = ExecutionResultCore.OK, ViewHtml = viewHtml });
        }

        protected virtual async Task<IActionResult> CreateJsonNotValidResultViewAsync(string viewName, object model = null, ModelStateDictionary modelStateDictionary = null, ExpandoObject viewBag = null)
        {
            if (string.IsNullOrWhiteSpace(viewName))
            {
                return Json(new ViewResultJsonResponse { Result = ExecutionResultCore.OK, ViewHtml = string.Empty });
            }

            string viewHtml = await ViewRenderService.RenderToString(viewName, model, modelStateDictionary, viewBag);
            return Json(new ViewResultJsonResponse { Result = ExecutionResultCore.NOTVALID, ViewHtml = viewHtml });
        }
    }
}

