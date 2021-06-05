using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Interfaces
{
    public interface IPackageSlip
    {
        void GenerateSlip();

        void GenerateDuplicateSlip();
    }
}
