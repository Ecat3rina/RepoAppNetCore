using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoApp.Common.DataTables
{
    public class DataTableJsonResponse<RecordModelT> where RecordModelT : class
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IEnumerable<RecordModelT> Data { get; set; }
        public string Error { get; set; }
    }
}
