using System;

namespace QuickBooksIntegration.Base
{
    public class ExpensesBase
    {
        //public int AdvertisingAndPromotionID { get; set; }               
        public string ListID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
        public string EditSequence { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public int Sublevel { get; set; }
        public string AccountType { get; set; }
        public int AccountNumber { get; set; }
        public string Desc { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalBalance { get; set; }
        public string CashFlowClassification { get; set; }
        public string ParentRefListID { get; set; }
        public string ParentRefFullName { get; set; }
        public string SpecialAccountType { get; set; }
        public string BankNumber { get; set; }
        public string TaxLineName { get; set; }
        public string TaxLineID { get; set; }
    }
}
