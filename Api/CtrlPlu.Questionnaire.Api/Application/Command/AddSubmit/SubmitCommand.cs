using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Cqrs;

namespace CtrlPlu.Questionnaire.Api.Application.Command.AddSubmit
{
    public class SubmitCommand : ICommand
    {
        public int FormId { get; set; }

        public IEnumerable<FiledsValue> FiledsValues { get; set; }
    }

    public class FiledsValue
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public IEnumerable<string> Values { get; set; }
    }
}
