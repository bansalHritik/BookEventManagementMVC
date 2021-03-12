using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Shared
{
    public interface ISampleFacade:IFacade
    {
        OperationResult<SampleDTO> SampleMethod(SampleDTO sampleDTO);
    }
}
