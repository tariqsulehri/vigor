using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public  interface IIndUnitOfMeasureRepository
    {
        void Add(IndUnitOfMeasure indUnitOfMeasure);
        void Edit(IndUnitOfMeasure indUnitOfMeasure);
        bool Remove(IndUnitOfMeasure indUnitOfMeasure);
        IndUnitOfMeasure FindById(int id);
        bool IsDuplicate(IndUnitOfMeasure indUnitOfMeasure);
        IEnumerable<IndUnitOfMeasure> GetAllIndUnitOfMeasure();
    }
}
