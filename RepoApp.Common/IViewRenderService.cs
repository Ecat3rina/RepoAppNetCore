using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Dynamic;
using System.Threading.Tasks;

namespace RepoApp.Common
{
    public interface IViewRenderService
    {
         Task<string> RenderToString(string viewName, object model, ModelStateDictionary modelStateDictionary, ExpandoObject viewBag);
    }
}