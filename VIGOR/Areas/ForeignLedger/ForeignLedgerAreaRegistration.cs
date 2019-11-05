using System.Web.Mvc;

namespace VIGOR.Areas.ForeignLedger
{
    public class ForeignLedgerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ForeignLedger";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ForeignLedger_default",
                "ForeignLedger/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}