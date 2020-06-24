using System.Collections.Generic;
using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Common.Core.Model;

namespace CtrlPlu.Questionnaire.Common.Core.UnitOFWork
{
    public interface IMappingService<T, TVM> where T : BaseEntity where TVM : IVM
    {
        T MapToEntity(TVM model);
        TVM MapToModel(T entity);
        IList<T> MapToEntity(IList<TVM> model);
        IList<TVM> MapToModel(IList<T> entity);
    }
}
