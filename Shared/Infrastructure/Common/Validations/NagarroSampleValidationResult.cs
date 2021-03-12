using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Shared
{
    public class NagarroSampleValidationResult
    {
        public IList<NagarroSampleValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public NagarroSampleValidationResult(IList<NagarroSampleValidationFailure> failures)
        {
            Errors = failures;
        }

        public NagarroSampleValidationResult()
        {
            Errors = new List<NagarroSampleValidationFailure>();
        }
    }
}
