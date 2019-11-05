using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IQcInspectorRepository
    {
        void Add(QcInspector qcInspector);
        void Edit(QcInspector qcInspector);
        bool Remove(QcInspector qcInspector);
        QcInspector FindById(int id);
        bool IsDuplicate(QcInspector qcInspector);
        IEnumerable<QcInspector> GetAllQcInspector();
    }
}
