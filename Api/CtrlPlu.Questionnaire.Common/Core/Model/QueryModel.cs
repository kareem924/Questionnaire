namespace CtrlPlu.Questionnaire.Common.Core.Model
{
    public class QueryModel
    {
        public QueryModel()
        {
            CurrentPage = 1;
            PageSize = 10;
            Sort = "Id";
            SortDirection = "des";
            SearchTerm = string.Empty;
        }
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }

        public string SortDirection { get; set; }

        public string SearchTerm { get; set; }
    }
}