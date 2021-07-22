using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
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

namespace RepoApp.WEB.Controllers
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

        protected JsonResult CreateDataTablesResult<Record>(IEnumerable<Record> records, DataTablesParameters parameters)
        {
            return Json(new { draw = parameters.Draw, recordsTotal = parameters.TotalCount, recordsFiltered = parameters.TotalCount, data = records });
        }



        protected ViewResult CreateExceptionView(Exception exception)
        {
            logger.Error(exception, "Custom CreateExceptionView Exception (BaseController)");

            ViewBag.Message = exception.Message;
            return View("~/Views/Shared/Error.cshtml");

        }


        //protected JsonResult JsonNet(object data)
        //{
        //    return new JsonNetResult
        //    {
        //        Data = data
        //    } as JsonResult;
        //}

        //protected JsonResult JsonNet(object data, JsonRequestBehavior behavior)
        //{
        //    return new JsonNetResult
        //    {
        //        Data = data,
        //        JsonRequestBehavior = behavior
        //    } as JsonResult;
        //}

        //protected JsonResult JsonNet(object data, string contentType)
        //{
        //    return new JsonNetResult
        //    {
        //        ContentType = contentType,
        //        Data = data
        //    } as JsonResult;
        //}

        //protected JsonResult JsonNet(object data, string contentType, JsonRequestBehavior behavior)
        //{
        //    return new JsonNetResult
        //    {
        //        ContentType = contentType,
        //        Data = data,
        //        JsonRequestBehavior = behavior
        //    } as JsonResult;
        //}

        //protected JsonResult JsonNet(object data, string contentType, System.Text.Encoding contentEncoding)
        //{
        //    return new JsonNetResult
        //    {
        //        ContentType = contentType,
        //        ContentEncoding = contentEncoding,
        //        Data = data
        //    } as JsonResult;
        //}

        //protected JsonResult JsonNet(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        //{
        //    return new JsonNetResult
        //    {
        //        ContentType = contentType,
        //        ContentEncoding = contentEncoding,
        //        Data = data,
        //        JsonRequestBehavior = behavior
        //    } as JsonResult;
        //}

        //protected virtual JsonResult CreateJsonError()
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.ERROR, Message = "Обратись к администратору", LongMessage = "" });
        //}

        //protected virtual JsonResult CreateJsonError(string message)
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.ERROR, Message = message, LongMessage = "" });
        //}

        //protected virtual JsonResult CreateJsonError(string message, string longMessage)
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.ERROR, Message = message, LongMessage = longMessage });
        //}

        //protected virtual JsonResult CreateJsonOK()
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.OK, Message = "", LongMessage = "" });
        //}

        //protected virtual JsonResult CreateJsonOK(string message)
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.OK, Message = message, LongMessage = "" });
        //}

        //protected virtual JsonResult CreateJsonOK(string message, string longMessage)
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.OK, Message = message, LongMessage = "" });
        //}

        //protected virtual JsonResult CreateJsonResult<T>(T data) where T : class, new()
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.OK, Message = "", LongMessage = "", Data = data });
        //}

        //protected virtual JsonResult CreateJsonResult<T>(IEnumerable<T> data) where T : class, new()
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.OK, Message = "", LongMessage = "", Data = data });
        //}

        //protected virtual JsonResult CreateJsonResult<T>(T data, string message) where T : class, new()
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.OK, Message = message, LongMessage = "", Data = data });
        //}


        //protected virtual JsonResult CreateJsonResult<RecordModelT>(RecordModelT[] array) where RecordModelT : class, new()
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.OK, Message = "", LongMessage = "", Data = array });
        //}

        //protected virtual JsonResult CreateJsonResult(string[] array)
        //{
        //    return JsonNet(new ExecutionResult { ExecutionStatus = ResultOutcome.OK, Message = "", LongMessage = "", Data = array });
        //}

        //public string ViewToHtml(ControllerContext context, string viewPath, object model = null)
        //{
        //    context.Controller.ViewData.Model = model;
        //    using (var writer = new StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindView(context, viewPath, null);
        //        var viewContext = new ViewContext(context, viewResult.View, context.Controller.ViewData, context.Controller.TempData, writer);

        //        viewResult.View.Render(viewContext, writer);
        //        viewResult.ViewEngine.ReleaseView(context, viewResult.View);
        //        return writer.GetStringBuilder().ToString();
        //    }
        //}

        //public virtual JsonResult JsonViewValidResult(string viewPath, object model = null)
        //{
        //    string view = string.IsNullOrWhiteSpace(viewPath) ? string.Empty : ViewToHtml(this.ControllerContext, viewPath, model);
        //    return Json(new { validationResult = ValidationResult.Valid, viewPage = view }, JsonRequestBehavior.AllowGet);
        //}

        //public virtual JsonResult JsonViewUnValidResult(string viewPath, object model = null)
        //{
        //    string view = string.IsNullOrWhiteSpace(viewPath) ? string.Empty : ViewToHtml(this.ControllerContext, viewPath, model);
        //    return Json(new { validationResult = ValidationResult.UnValid, viewPage = view }, JsonRequestBehavior.AllowGet);
        //}







        //protected virtual IActionResult CreateDataTableResult<RecordModelT>(IEnumerable<RecordModelT> records, DataTablesParameters parameters) where RecordModelT : class, new()
        //{
        //    return Json(new DataTableJsonResponse<RecordModelT> { Draw = parameters.Draw, RecordsTotal = parameters.TotalCount, RecordsFiltered = parameters.TotalCount, Data = records });
        //}

        //protected virtual IActionResult CreateDataTableError(string message)
        //{
        //    return Json(new DataTableJsonResponse<string> { Draw = 0, RecordsTotal = 0, RecordsFiltered = 0, Data = Array.Empty<string>(), Error = message });
        //}

        //protected virtual IActionResult CreateJsonOk(string message = null, bool showToast = false)
        //{
        //    return Json(new BaseJsonResponse { Result = ExecutionResult.OK, Message = message, ShowToast = showToast });
        //}

        //protected virtual IActionResult CreateJsonOk<RecordModelT>(RecordModelT record, string message = null, bool showToast = false) where RecordModelT : class
        //{
        //    return Json(new SingleJsonResponse<RecordModelT> { Result = ExecutionResult.OK, Message = message, ShowToast = showToast, Record = record });
        //}

        //protected virtual IActionResult CreateJsonOk<RecordModelT>(IEnumerable<RecordModelT> records, string message = null, bool showToast = false) where RecordModelT : class
        //{
        //    return Json(new CollectionJsonResponse<RecordModelT> { Result = ExecutionResult.OK, Message = message, ShowToast = showToast, Records = records });
        //}

        //protected virtual IActionResult CreateJsonOk<RecordModelT>(ICollection<RecordModelT> records, string message = null, bool showToast = false) where RecordModelT : class
        //{
        //    return Json(new CollectionJsonResponse<RecordModelT> { Result = ExecutionResult.OK, Message = message, ShowToast = showToast, Records = records });
        //}

        //protected virtual IActionResult CreateJsonOk<RecordModelT>(List<RecordModelT> records, string message = null, bool showToast = false) where RecordModelT : class
        //{
        //    return Json(new CollectionJsonResponse<RecordModelT> { Result = ExecutionResult.OK, Message = message, ShowToast = showToast, Records = records });
        //}

        //protected virtual IActionResult CreateJsonKo(string message = null)
        //{
        //    return Json(new BaseJsonResponse { Result = ExecutionResult.KO, Message = message });
        //}

        //protected virtual IActionResult CreateJsonError(string message = null)
        //{
        //    return Json(new BaseJsonResponse { Result = ExecutionResult.ERROR, Message = message });
        //}

        //protected virtual IActionResult CreateJsonException(Exception exception)
        //{
        //    return Json(new ExceptionJsonResponse { Message = exception.Message, StackTrace = exception.StackTrace });
        //}

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

