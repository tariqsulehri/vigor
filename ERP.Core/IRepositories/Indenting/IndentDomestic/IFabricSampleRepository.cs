using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IFabricSampleRepository
    {
        void Add(FabricSample fabricSample);
        void Edit(FabricSample fabricSample);
        bool Remove(FabricSample fabricSample);
        FabricSample FindById(int id);
        IEnumerable<FabricSample> GetAllFabricSamples();
    }
}
