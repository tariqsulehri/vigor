using ERP.Core.IRepositories.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            IndentInfo indentInfo = new IndentInfo
            {
                IndentId = indDomestic.Id,
                SalesContractNo = indDomestic.IndentKey,
                SellerContractNo = indDomestic.SuppContract,
                PurchaseOrderNo = indDomestic.PONumber,
                CompanyID = indDomestic.CompanyId
            };

            db.IndentInfos.Add(indentInfo);
            db.SaveChanges();
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
                        var cmd = ("DELETE FROM IndDomesticDetails WHERE IndentKey = '" + indDomestic.IndentKey + "'");
                        db.Database.ExecuteSqlCommand(cmd);
                        //db.SaveChanges();

                        //foreach (var agent in IndentAgent)
                        //{
                        //    db.IndentAgents.Add(agent);
                        //}
                        //db.SaveChanges();

                        IndentInfo indentInfo = new IndentInfo
                        {
                            IndentId = indDomestic.Id,
                            SalesContractNo = indDomestic.IndentKey,
                            SellerContractNo = indDomestic.SuppContract,
                            PurchaseOrderNo = indDomestic.PONumber,
                            CompanyID = indDomestic.CompanyId
                        };


                        foreach (var vDetail in indDomestic.IndDomesticDetails)
                        {
                            IndDomesticDetail dtl = new IndDomesticDetail()
                            {
                                SalesContractDetailID = vDetail.SalesContractDetailID,
                                IndentId = indDomestic.Id,
                                IndentKey = vDetail.IndentKey,
                                CommodityId = vDetail.CommodityId,
                                CommoditySpecification = vDetail.CommoditySpecification,
                                UosID = vDetail.UosID,
                                Quantity = vDetail.Quantity,
                                Rate = vDetail.Rate,
                                CommRate = vDetail.CommRate,
                                Stuffing = vDetail.Stuffing,
                                SizeCode = vDetail.SizeCode,
                                SizeSpecifications = vDetail.SizeSpecifications,
                                GSM = vDetail.GSM,
                                PerPieceWeight = vDetail.PerPieceWeight,
                                PerPieceUnitWeight = vDetail.PerPieceUnitWeight,
                                LabDip = vDetail.LabDip,
                                LabDipDate = vDetail.LabDipDate,
                                LabDipOption = vDetail.LabDipOption,
                                WeightDispatched = vDetail.WeightDispatched,
                                TypeColor = vDetail.TypeColor,
                                FabricWidth = vDetail.FabricWidth,
                                QuantityReq = vDetail.QuantityReq,
                                UnitQuantityReq = vDetail.UnitQuantityReq,
                                BarCode = vDetail.BarCode,
                                TotalValue = vDetail.TotalValue,
                                TotalValueOnCommRate = vDetail.TotalValueOnCommRate,
                                ExecutedQuantity = vDetail.ExecutedQuantity,
                                ExecutedValue = vDetail.ExecutedValue,
                                QuantityPerFCL = vDetail.QuantityPerFCL,
                                ColourId = vDetail.ColourId,
                                SuppliorCode = vDetail.SuppliorCode,
                                DesignId = vDetail.DesignId,
                                DesignNo = vDetail.DesignNo


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
            qty = db.IndDomesticDetail.Where(x => x.IndentId == id && x.CommodityId == commodityId).Select(x => x.Quantity).SingleOrDefault();
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
        public string IndentKey(string keyType)
        {
            string IndentKey = "";

            if (keyType == "local")
            {
                int maxno = db.IndDomestic.Count();
                maxno = maxno + 1;
                IndentKey = "VILC" + maxno.ToString().PadLeft(6, '0');
            }

            if (keyType == "export")
            {
                int maxno = db.IndDomestic.Count();
                maxno = maxno + 1;
                IndentKey = "VILC" + maxno.ToString().PadLeft(6, '0');
            }

            return IndentKey;
        }

        public int GetIndIdByKey(String Key)
        {
            var q = db.IndDomestic.FirstOrDefault(x => x.IndentKey == Key);
            int id = q.Id;
            return id;
        }
        public void Add(IndDomestic indDomestic, ICollection<IndentAgent> indentAgent)
        {
            db.IndDomestic.Add(indDomestic);
            db.SaveChanges();
            var indId = GetIndIdByKey(indDomestic.IndentKey);

            foreach (var agent in indentAgent)
            {
                agent.IndentId = indId;
                db.IndentAgents.Add(agent);
            }
            db.SaveChanges();

            IndentInfo indentInfo = new IndentInfo
            {
                IndentId = indDomestic.Id,
                SalesContractNo = indDomestic.IndentKey,
                SellerContractNo = indDomestic.SuppContract,
                PurchaseOrderNo = indDomestic.PONumber,
                CompanyID = indDomestic.CompanyId
            };

            db.IndentInfos.Add(indentInfo);
            db.SaveChanges();

        }


        public IEnumerable<IndentAgent> GetAgentsByIndentId(int indentId)
        {
            return db.IndentAgents.Where(x => x.IndentId == indentId).ToList();
        }

        public void Edit(IndDomestic indDomestic, ICollection<IndentAgent> indentAgent)
        {
            IndDomestic existingRecord = db.IndDomestic.Find(indDomestic.Id);

            if (existingRecord != null)
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {

                        var cmd1 = ("DELETE FROM IndentAgents WHERE IndentId = '" + indDomestic.Id + "'");
                        db.Database.ExecuteSqlCommand(cmd1);

                        foreach (var agent in indentAgent)
                        {
                            db.IndentAgents.Add(agent);
                        }

                        db.SaveChanges();

                        var cmd2 = ("DELETE FROM IndentInfoes WHERE IndentId = '" + indDomestic.Id + "'");
                        db.SaveChanges();

                        IndentInfo indentInfo = new IndentInfo
                        {
                            IndentId = indDomestic.Id,
                            SalesContractNo = indDomestic.IndentKey,
                            SellerContractNo = indDomestic.SuppContract,
                            PurchaseOrderNo = indDomestic.PONumber,
                            CompanyID = indDomestic.CompanyId
                        };

                        db.SaveChanges();

                        db.IndDomestic.Attach(existingRecord);
                        db.Entry(existingRecord).CurrentValues.SetValues(indDomestic);
                        //db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
                        //db.SaveChanges();
                        var cmdCom = ("DELETE FROM IndCommissions WHERE IndentKey = '" + indDomestic.IndentKey + "'");
                        db.Database.ExecuteSqlCommand(cmdCom);

                        var cmd = ("DELETE FROM IndDomesticDetails WHERE IndentKey = '" + indDomestic.IndentKey + "'");
                        db.Database.ExecuteSqlCommand(cmd);
                        //db.SaveChanges();

                        foreach (var commDetail in indDomestic.IndCommission)
                        {
                            IndCommission indComm = new IndCommission()
                            {
                                SaleContractCommID = commDetail.SaleContractCommID,
                                IndentId = commDetail.IndentId,
                                IndentKey = commDetail.IndentKey,
                                CustomerIdCommPaidTo = commDetail.CustomerIdCommPaidTo,
                                CustomerIdCommPaidFrom = commDetail.CustomerIdCommPaidFrom,
                                CommissionRate = commDetail.CommissionRate,
                                CommissionType = commDetail.CommissionType,
                                IsinLocalCurrecncy = commDetail.IsinLocalCurrecncy,
                                CommissionValue = commDetail.CalculatedCommissionValue,
                                Remarks = commDetail.Remarks,
                                CalculatedCommissionValue = commDetail.CalculatedCommissionValue,
                                CompanyId = commDetail.CompanyId,
                                TTRoutingInstructions = commDetail.TTRoutingInstructions,
                                IsPrintable = commDetail.IsPrintable,
                                CustomerIdCommPaidTo_Ref = commDetail.CustomerIdCommPaidTo_Ref,
                                CustomerIdCommPaidFrom_Ref = commDetail.CustomerIdCommPaidFrom_Ref,
                                CompanyId_Ref = commDetail.CompanyId_Ref,
                                CreatedBy = commDetail.CreatedBy,
                                CreatedOn = commDetail.CreatedOn,
                                ModifiedBy = commDetail.ModifiedBy,
                                ModifiedOn = commDetail.ModifiedOn
                            };
                            db.IndCommission.Add(indComm);
                        }
                        db.SaveChanges();

                        foreach (var vDetail in indDomestic.IndDomesticDetails)
                        {
                            IndDomesticDetail dtl = new IndDomesticDetail()
                            {
                                SalesContractDetailID = vDetail.SalesContractDetailID,
                                IndentId = indDomestic.Id,
                                IndentKey = vDetail.IndentKey,
                                CommodityId = vDetail.CommodityId,
                                CommoditySpecification = vDetail.CommoditySpecification,
                                UosID = vDetail.UosID,
                                Quantity = vDetail.Quantity,
                                Rate = vDetail.Rate,
                                CommRate = vDetail.CommRate,
                                Stuffing = vDetail.Stuffing,
                                SizeCode = vDetail.SizeCode,
                                SizeSpecifications = vDetail.SizeSpecifications,
                                GSM = vDetail.GSM,
                                PerPieceWeight = vDetail.PerPieceWeight,
                                PerPieceUnitWeight = vDetail.PerPieceUnitWeight,
                                LabDip = vDetail.LabDip,
                                LabDipDate = vDetail.LabDipDate,
                                LabDipOption = vDetail.LabDipOption,
                                WeightDispatched = vDetail.WeightDispatched,
                                TypeColor = vDetail.TypeColor,
                                FabricWidth = vDetail.FabricWidth,
                                QuantityReq = vDetail.QuantityReq,
                                UnitQuantityReq = vDetail.UnitQuantityReq,
                                BarCode = vDetail.BarCode,
                                TotalValue = vDetail.TotalValue,
                                TotalValueOnCommRate = vDetail.TotalValueOnCommRate,
                                ExecutedQuantity = vDetail.ExecutedQuantity,
                                ExecutedValue = vDetail.ExecutedValue,
                                QuantityPerFCL = vDetail.QuantityPerFCL,
                                ColourId = vDetail.ColourId,
                                SuppliorCode = vDetail.SuppliorCode,
                                DesignId = vDetail.DesignId,
                                DesignNo = vDetail.DesignNo
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

    }

}
