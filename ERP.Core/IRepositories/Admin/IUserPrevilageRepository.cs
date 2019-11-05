using ERP.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Admin
{
    public interface IUserPrevilageRepository
    {
        void Add(UserPrevilage userPrevilage);
        void Edit(UserPrevilage userPrevilage);
        bool Remove(UserPrevilage userPrevilage);
        UserPrevilage FindById(int id);
        bool IsDuplicate(UserPrevilage userPrevilage);
        IEnumerable<UserPrevilage> GetAllUserPrevilages();
        IEnumerable<UserPrevilage> GetAllUserPrevilagesByUserId(int userid);

    }
}
