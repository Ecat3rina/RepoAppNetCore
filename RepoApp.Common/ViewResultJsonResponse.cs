using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RepoApp.Common.EnumsCore;

namespace RepoApp.Common
{
    public class ViewResultJsonResponse
    {
        public ExecutionResultCore Result { get; set; }
        public string ViewHtml { get; set; }

    }
}
