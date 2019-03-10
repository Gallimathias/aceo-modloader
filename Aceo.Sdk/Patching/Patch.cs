using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aceo.Sdk.Patching
{
    public abstract class Patch
    {
        public abstract string TargetType { get; }
    }
}
