using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExpenseCommon;

namespace ExpenseTrackerService.CategoryModule
{
     [ServiceContract]
    public interface ICategoriesManagerService
    {
        [OperationContract]
         Boolean AddCategory(Category category);

          [OperationContract]
        Boolean UpdateCategory(Category category);

          [OperationContract]
          Boolean RemoveCategory(Category category);
         
          [OperationContract]
        List<Category> GetCategories(Int32 userId);
    }
}
