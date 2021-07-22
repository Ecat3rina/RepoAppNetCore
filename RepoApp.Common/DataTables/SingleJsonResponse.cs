using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RepoApp.Common.EnumsCore;

namespace RepoApp.Common.DataTables
{
    public class SingleJsonResponse<RecordModelT> where RecordModelT : class
    {
        public ExecutionResultCore Result { get; set; }
        public string Message { get; set; }
        public bool ShowToast { get; set; }
        public RecordModelT Record { get; set; }
    }
}
