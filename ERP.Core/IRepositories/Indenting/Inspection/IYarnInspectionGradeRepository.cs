using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IYarnInspectionGradeRepository
    {
        void Add(YarnInspectionGrade yarnInspectionGrade);
        void Edit(YarnInspectionGrade yarnInspectionGrade);
        bool Remove(YarnInspectionGrade yarnInspectionGrade);
        YarnInspectionGrade FindById(int id);
        bool IsDuplicate(YarnInspectionGrade yarnInspectionGrade);
        IEnumerable<YarnInspectionGrade> GetAllYarnInspectionGrades();

    }
}
