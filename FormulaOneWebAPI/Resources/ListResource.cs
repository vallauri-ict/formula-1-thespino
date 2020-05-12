using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FormulaOneWebAPI.Resources
{
    [DataContract(Name = "Resource")]
    public class ListResource<T>
    {
        public ListResource(int page, int pages, int limit, long count, IEnumerable<T> data)
        {
            this.Page = page;
            this.Limit = limit;
            this.Pages = pages;
            this.Count = count;
            this.Data = data;
        }

        public ListResource(PaginationResult<T> res, int page)
        {
            this.Page = page;
            this.Limit = res.PerPage;
            this.Pages = res.TotalPages;
            this.Count = res.Count;
            this.Data = res.List;
        }

        [DataMember(Name = "Page")]
        public int Page { get; private set; } = 1;

        [DataMember(Name = "Limit")]
        public int Limit { get; private set; } = 10;

        [DataMember(Name = "Pages")]
        public int Pages { get; private set; }

        [DataMember(Name = "Count")]
        public long Count { get; private set; }

        [DataMember(Name = "Data")]
        public IEnumerable<T> Data { get; private set; }
    }
}