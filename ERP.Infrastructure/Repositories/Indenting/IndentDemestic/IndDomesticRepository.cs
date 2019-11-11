using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Infrastructure.Repositories.Indenting.IndentDemestic
{
    public class IndDomesticRepository : IIndDomesticRepository
    {

        ErpDbContext db;
        public IndDomesticRepository()
        {
            db = new ErpDbContext();
        }
        public void Add(IndDomestic indDomestic)
        {
            indDomestic.IndentKey = IndentKey();
            db.IndDomestic.Add(indDomestic);
            db.SaveChanges();
        }

        public void Edit(IndDomestic indDomestic)
        {
            IndDomestic existingRecord = db.IndDomestic.Find(indDomestic.Id);

            if (existingRecord != null)
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.IndDomestic.Attach(existingRecord);
                        db.Entry(existingRecord).CurrentValues.SetValues(indDomestic);
                        //db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
                        //db.SaveChanges();
                        var cmd = ("DELETE FROM IndDomesticDetails WHERE IndentKey = '" + indDomestic.IndentKey+"'");
                        db.Database.ExecuteSqlCommand(cmd);
                        //db.SaveChanges();
                        foreach (var vDetail in indDomestic.IndDomesticDetails)
                        {
                            IndDomesticDetail dtl = new IndDomesticDetail()
                            {
                                SalesContractDetailID = vDetail.SalesContractDetailID,
                                IndentId = indDomestic.Id,
                                IndentKey = vDetail.IndentKey,
                                CommodityId = vDetail.CommodityId,
                                CommoditySpecification =  vDetail.CommoditySpecification,
                                UosID = vDetail.UosID,
                                Quantity =  vDetail.Quantity,
                                Rate =  vDetail.Rate,
                                CommRate =  vDetail.CommRate,
                                Stuffing =  vDetail.Stuffing,
                                SizeCode =  vDetail.SizeCode,
                                SizeSpecifications = vDetail.SizeSpecifications,
                                GSM =  vDetail.GSM,
                                PerPieceWeight =  vDetail.PerPieceWeight,
                                PerPieceUnitWeight =vDetail.PerPieceUnitWeight,
                                LabDip =  vDetail.LabDip,
                                LabDipDate =  vDetail.LabDipDate,
                                LabDipOption =  vDetail.LabDipOption,
                                WeightDispatched = vDetail.WeightDispatched,
                                TypeColor = vDetail.TypeColor,
                                FabricWidth =  vDetail.FabricWidth,
                                QuantityReq =  vDetail.QuantityReq,
                                UnitQuantityReq =  vDetail.UnitQuantityReq,
                                BarCode =  vDetail.BarCode,
                                TotalValue =  vDetail.TotalValue,
                                TotalValueOnCommRate = vDetail.TotalValueOnCommRate,
                                ExecutedQuantity =  vDetail.ExecutedQuantity,
                                ExecutedValue =  vDetail.ExecutedValue,
                                QuantityPerFCL =  vDetail.QuantityPerFCL,
                                ColourId =  vDetail.ColourId,
                                SuppliorCode =  vDetail.SuppliorCode,
                                DesignId =  vDetail.DesignId,
                                DesignNo =  vDetail.DesignNo

                            };

                            db.IndDomesticDetail.Add(dtl);

                        }

                         db.SaveChanges();
                         context.Commit();
                    }
                    catch (Exception e)
                    {
                        context.Rollback();
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
        }
        public void Update(IndDomestic indDomestic)
        {
            IndDomestic existingRecord = db.IndDomestic.Find(indDomestic.Id);

            if (existingRecord != null)
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {
                        existingRecord.IsSubmitForApproval = indDomestic.IsSubmitForApproval;
                        existingRecord.LastApprovedOn = indDomestic.LastApprovedOn;
                        existingRecord.IsApproved = indDomestic.IsApproved;
                        existingRecord.ApprovedBy = indDomestic.ApprovedBy;
                     
                        db.SaveChanges();
                        context.Commit();
                    }
                    catch (Exception e)
                    {
                        context.Rollback();
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
        }
        public IndDomestic FindById(int id)
        {
            IndDomestic ind = db.IndDomestic.Find(id);
            return ind;
        }


        public decimal GetIndentQuantityById(int id, int commodityId)
        {
             decimal qty;
             qty = db.IndDomesticDetail.Where(x => x.IndentId == id && x.CommodityId ==commodityId).Select(x => x.Quantity).SingleOrDefault();
             return qty;
        }

        public IEnumerable<IndDomestic> GetAllIndDomectic()
        {
            return db.IndDomestic.ToList();
        }

        public bool IsDuplicate(IndDomestic indDomestic)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IndDomestic indDomestic)
        {
            throw new NotImplementedException();
        }
        public string IndentKey()
        {
             
            int maxno = db.IndDomestic.Count();
            maxno = maxno + 1;
            string IndentKey = "VILC" + maxno.ToString().PadLeft(6, '0');
            return IndentKey;
        }
    }
}
