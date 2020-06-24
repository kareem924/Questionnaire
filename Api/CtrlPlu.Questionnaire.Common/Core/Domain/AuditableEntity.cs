using System;

namespace CtrlPlu.Questionnaire.Common.Core.Domain
{
    public abstract class AuditableEntity : BaseEntity
    {
        public int CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

    }
}
