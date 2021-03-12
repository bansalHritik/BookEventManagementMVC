using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Shared
{
    public interface ISampleDAC : IDataAccessComponent
    {
        SampleDTO SampleMethod(SampleDTO sampleDTO);
    }
}
