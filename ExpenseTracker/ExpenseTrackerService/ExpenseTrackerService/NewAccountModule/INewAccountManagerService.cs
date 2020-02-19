﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExpenseCommon;

namespace ExpenseTrackerService.NewAccountModule
{
     [ServiceContract]
    public interface INewAccountManagerService
    {
        [OperationContract]
         Boolean CreateNewAccount(User value);
    }
}
