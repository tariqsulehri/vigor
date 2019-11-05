using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IYarnInspUstersRepository
    {
        void Add(YarnInspUsters yarnInspUsters);
        void Edit(YarnInspUsters yarnInspUsters);
        bool Remove(YarnInspUsters yarnInspUsters);
        YarnInspUsters FindById(int id);
        bool IsDuplicate(YarnInspUsters yarnInspUsters);
        IEnumerable<YarnInspUsters> GetAllYarnInspUsters();
    }
}
