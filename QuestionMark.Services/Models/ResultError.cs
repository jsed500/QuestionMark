using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionMark.Services.Models
{
    public class ResultError<T>
    {
        public T Result { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool HasError => Errors?.Any() ?? false;
    }
}