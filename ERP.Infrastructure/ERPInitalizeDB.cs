using ERP.Infrastructure;
using System.Data.Entity;

namespace ERP.Infrastructure
{
    public class ErpInitLizeDb : DropCreateDatabaseIfModelChanges<ErpDbContext>
    {
        protected override void Seed(ErpDbContext dbContext)
        {
        //    context.Categorys.Add(new Category
        //    {
        //        Name = "Shoes"
        //    });

        //    context.Categorys.Add(new Category
        //    {
        //        Name = "Mobiles"
        //    });

        //    context.Categorys.Add(new Category
        //    {
        //        Name = "Electronics"
        //    });

        //    context.SaveChanges();

        //    context.Products.Add(new Product
        //    {
        //        ProductName = "Noke Shoes for Jogging",
        //        Description = "This is very Good shoes for jogging",
        //        Price = 1500,
        //        HotItem = true,
        //        Stock = 10,
        //        ImagePath = "No Image",
        //        CategoryID = 1
        //    });

        //    context.Products.Add(new Product
        //    {
        //        ProductName = "PEL Deep Freezer",
        //        Description = "Wel Colling and big Capicity",
        //        Price = 2500,
        //        HotItem = true,
        //        Stock = 10,
        //        ImagePath = "No Image",
        //        CategoryID = 3
        //    });

        //    context.SaveChanges();

        //    base.Seed(context);
        }
    }
}
