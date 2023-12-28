using Microsoft.AspNetCore.OData.Query.Expressions;
using Microsoft.OData.UriParser;
using System.Linq.Expressions;

namespace TestODataProject
{
    public class SearchBinder : QueryBinder, ISearchBinder
    {
        public Expression BindSearch<T>(SearchClause searchClause, QueryBinderContext context)
        {
            if (!typeof(T).IsAssignableFrom(context.ElementClrType))
            {
                return null;
            }

            return SearchBinderHelper.BindSearch<T>(searchClause);
        }

        public Expression BindSearch(SearchClause searchClause, QueryBinderContext context)
        {
            switch (System.Type.GetTypeCode(context.ElementClrType))
            {
                case TypeCode.Object:
                    return MasExpression(searchClause, context);

                default:
                    return null;
            }
        }

        #region BindSearch<T> Config        
        private Expression MasExpression(SearchClause searchClause, QueryBinderContext context)
        {
            return BindSearch<ChemicalPriceAndEconomics>(searchClause, context);
        }
        #endregion
    }
}
