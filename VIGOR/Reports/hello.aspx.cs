using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.FinRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Core.Models.Finance;
using VIGOR.ViewsModel;

namespace VIGOR.Reports
{
    public partial class hello : System.Web.UI.Page
    {
        private CoaL1Repository coaL1Repository;
        private ErpDbContext bdContext;
        private Entities dbEntities;
        public hello()
        {
            coaL1Repository = new CoaL1Repository();
            bdContext = new ErpDbContext();
            dbEntities = new Entities();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LueAccounts();
        }
        private void LueAccounts()
        {

            var list = coaL1Repository.GetL1Accounts();
            CoaL1 model = new CoaL1();
            List<CoaL1> lstCoa = new List<CoaL1>();
            foreach (var coal1 in list)
            {
                model = new CoaL1();
                model.L1Code = coal1.L1Code;
                model.Title = coal1.Title;
                lstCoa.Add(model);
                foreach (var coal2 in coal1.CoaL2.Where(a => a.L1Code == coal1.L1Code))
                {
                    model = new CoaL1();
                    model.L1Code = coal2.L2Code;
                    model.Title = coal2.Title;
                    lstCoa.Add(model);
                    foreach (var coal3 in coal2.CoaL3.Where(a => a.L2Code == coal2.L2Code))
                    {
                        model = new CoaL1();
                        model.L1Code = coal3.L3Code;
                        model.Title = coal3.Title;
                        lstCoa.Add(model);
                        foreach (var coal4 in coal3.CoaL4.Where(a => a.L3Code == coal3.L3Code))
                        {
                            model = new CoaL1();
                            model.L1Code = coal4.L4Code;
                            model.Title = coal4.Title;
                            lstCoa.Add(model);
                            foreach (var coal5 in coal4.CoaL5.Where(a => a.L4Code == coal4.L4Code))
                            {
                                model = new CoaL1();
                                model.L1Code = coal5.L5Code;
                                model.Title = coal5.Title;
                                lstCoa.Add(model);
                            }
                        }
                    }
                }
            }



            grdgstAccount.DataSource = null;
grdgstAccount.DataSource= lstCoa.OrderBy(a => a.L1Code);
            grdgstAccount.DataBind();
        }

        protected void lnkSendCode_Click(object sender, EventArgs e)
        {
            LinkButton Lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;
            GetSelecteRow(row);
        }

        protected void GetSelecteRow(GridViewRow GrdRow)
        {
            try
            {
                string Code  = ((Label)GrdRow.FindControl("lblcode")).Text;
                string Title = ((Label)GrdRow.FindControl("lblTitle")).Text;
                
            }
            catch (Exception ex)
            {
            }
        }
    }
}