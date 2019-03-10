using Aceo.Sdk;
using Aceo.Sdk.Patching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusNamesMod
{
    public class BusModelPatch : Patch
    {
        public override string TargetType => "BusModel";

        [Override]
        private readonly string[] availTypes = new string[]
        {
            "Volvo",
            "Skania",
            "VanHool",
            "MAN",
            "Alexander Dennis"
        };

        [Override]
        private readonly string[] availCompanies = new string[]
        {
            "CapitalConnect",
            "AirBus",
            "Enterprise Rental Car Shuttle",
            "Lot A Shuttle",
            "Lot B Shuttle"
        };
    }
}
