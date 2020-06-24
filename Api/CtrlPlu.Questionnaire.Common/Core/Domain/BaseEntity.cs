using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CtrlPlu.Questionnaire.Common.Core.Domain
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            //CreatedDate = Helpers.Utilities.FormatDateForDB(DateTime.UtcNow);
            //FlgStatus = 1;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
