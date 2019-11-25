using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ERP.Core.IRepositories.Indenting.IndentExport;
using ERP.Core.Models.Indenting.IndentExport;

namespace ERP.Infrastructure.Repositories.Indenting.IndentExport
{
    public class IndExportShipmentScheduleRepository : IIndExportShipmentScheduleRepository
    {
        private ErpDbContext db;
        public IndExportShipmentScheduleRepository()
        {
           db =  new ErpDbContext();
        }
        public void Add(IndExportShipmentScheduleMaster IndExportShipmentScheduleMaster)
        {
            db.IndExportShipmentScheduleMaster.Add(IndExportShipmentScheduleMaster);
            db.SaveChanges();
        }

        public void Edit(IndExportShipmentScheduleMaster IndExportShipmentScheduleMaster)
        {
            IndExportShipmentScheduleMaster existingRecord = db.IndExportShipmentScheduleMaster.Find(IndExportShipmentScheduleMaster.Id);
            if (existingRecord != null)
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {

                        db.Entry(existingRecord).CurrentValues.SetValues(IndExportShipmentScheduleMaster);
                        db.SaveChanges();

                        var cmd = ("DELETE FROM IndExportShipmentScheduleDetails WHERE ShipmentScheduleKey = '" + IndExportShipmentScheduleMaster.ShipmentScheduleKey + "'");
                        db.Database.ExecuteSqlCommand(cmd);
                        db.SaveChanges();

                        foreach (var vDetail in IndExportShipmentScheduleMaster.IndExportShipmentScheduleDetails)
                        {



                            IndExportShipmentScheduleDetail dtl = new IndExportShipmentScheduleDetail();

                            var config = new MapperConfiguration(cfg => {
                                cfg.CreateMap<IndExportShipmentScheduleDetail, IndExportShipmentScheduleDetail>();
                            });

                            IMapper iMapper = config.CreateMapper();

                            var destination = iMapper.Map<IndExportShipmentScheduleDetail, IndExportShipmentScheduleDetail>(vDetail);
                            existingRecord.IndExportShipmentScheduleDetails.Add(destination);

                        }
                     
                        db.Database.ExecuteSqlCommand(cmd);
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

        public bool Remove(IndExportShipmentScheduleMaster IndExportShipmentScheduleMaster)
        {
            throw new System.NotImplementedException();
        }

        public IndExportShipmentScheduleMaster FindById(int id)
        {
            IndExportShipmentScheduleMaster rc = db.IndExportShipmentScheduleMaster.Find(id);
            return rc;
        }

        public IEnumerable<IndExportShipmentScheduleMaster> GetAllIndExportShipmentScheduleMaster()
        {
            IEnumerable<IndExportShipmentScheduleMaster> ssh = db.IndExportShipmentScheduleMaster.ToList();
            return ssh;
        }
    }
}
