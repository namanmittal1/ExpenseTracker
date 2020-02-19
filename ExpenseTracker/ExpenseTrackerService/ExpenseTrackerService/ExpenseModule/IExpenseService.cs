using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ExpenseCommon;

namespace ExpenseTrackerService.ExpenseModule
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IExpenseService
    {
        [OperationContract]
        Boolean EnterExpense(Expense value);

        [OperationContract]
        List<Category> GetCategories(Int32 userId);

        [OperationContract]
        List<Item> GetItems(Int32 userId);

        [OperationContract]
        Item GetSelectedItem(Item item);


        // TODO: Add your service operations here
    }

}
