using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Core.IRepositories.Indenting.InspExport
{
    public interface IFabricInspRptExp4PFormat2Repository
    {
        void Add(FabricInspRptExp4PFormat2 FabricInspRptExp4PFormat2);
        void Edit(FabricInspRptExp4PFormat2 FabricInspRptExp4PFormat2);
        bool Remove(FabricInspRptExp4PFormat2 FabricInspRptExp4PFormat2);
        FabricInspRptExp4PFormat2 FindById(string Format2No);
        bool IsDuplicate(FabricInspRptExp4PFormat2 FabricInspRptExp4PFormat2);
        IEnumerable<FabricInspRptExp4PFormat2> GetAllFabricInspRptExp4PFormat2s();
    }
}
