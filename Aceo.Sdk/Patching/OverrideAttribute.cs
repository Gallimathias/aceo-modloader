using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aceo.Sdk.Patching
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field,
        AllowMultiple = false, Inherited = false)]
    public class OverrideAttribute : Attribute
    {
        public OverrideAttribute()
        {
        }
    }
}
