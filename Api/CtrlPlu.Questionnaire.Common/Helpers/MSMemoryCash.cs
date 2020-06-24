using Microsoft.Extensions.Caching.Memory;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public class MSMemoryCash : IMSMemoryCash
    {
        private readonly IMemoryCache _cache;

        public MSMemoryCash(IMemoryCache cache)
        {
            _cache = cache;
        }
        
        public void CashItem(string tokenKey, object item)
        {
            _cache.Set(tokenKey, item);
        }

        public object GetCashItem(string itemKey)
        {
            _cache.TryGetValue(itemKey, out object item);
            return item;
        }
    }
}
