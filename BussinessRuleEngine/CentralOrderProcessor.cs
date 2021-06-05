using System;
using BusinessRuleEngine.Interfaces;
using BussinessRuleEngine.Interfaces;

namespace BussinessRuleEngine
{
    public class CentralOrderProcessor
    { 
        public void ProcessOrder(IItemOrder itemOrder)
        {
            itemOrder.ExecuteOrder();
        }
    } 
}
