namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public interface IMSMemoryCash
    {
        void CashItem(string tokenKey, object item);
        object GetCashItem(string itemKey);
    }
}
