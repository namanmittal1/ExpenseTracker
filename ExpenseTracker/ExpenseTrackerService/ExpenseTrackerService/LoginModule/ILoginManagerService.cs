using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExpenseCommon;

namespace ExpenseTrackerService.LoginModule
{
     [ServiceContract]
    public interface ILoginManagerService
    {
        [OperationContract]
        Int32 Login(User user);

        [OperationContract]
        Boolean Logout();      

        [OperationContract]
        Int32 GetCurrentUser();

        [OperationContract]
        Int32 GetUsersCount();
    }
}
