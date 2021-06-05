using BusinessRuleEngine.Interfaces;
using BussinessRuleEngine.Interfaces;

namespace BussinessRuleEngine.Items
{
    public class BookItem:IItemOrder
    {
        private readonly ICommission _commission;
        private readonly IPackageSlip _packageSlip;
        public BookItem(ICommission commission, IPackageSlip packageSlip)
        {
            _packageSlip = packageSlip;
            _commission = commission; 
        }

        public void ExecuteOrder()
        {
            _packageSlip.GenerateSlip();
            _commission.GenerateCommission();
        }   
    }
}
