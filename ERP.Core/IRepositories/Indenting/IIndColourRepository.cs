using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndColourRepository
    {
        void Add(IndColour indColour);
        void Edit(IndColour indColour);
        bool Remove(IndColour indColour);
        IndColour FindById(int id);
        bool IsDuplicate(IndColour indColour);
        IEnumerable<IndColour> GetAllIndColours();
    }
}
