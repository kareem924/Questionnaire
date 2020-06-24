namespace CtrlPlu.Questionnaire.Common.Context
{
    public interface IWorkContext
    {
        ContextUser User { get; }
        string Lang { get; }
    }

}
