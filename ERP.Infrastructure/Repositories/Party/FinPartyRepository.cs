using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.FinPartiesIRepository;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Infrastructure.Repositories.Parties
{
    public class FinPartyRepository : IFinPartyRepository
    {

        private readonly ErpDbContext _db;

        public FinPartyRepository()
        {
            _db = new ErpDbContext();
        }
        public void Add(FinParty finParty)
        {
            using (var context = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.FinParties.Add(finParty);
                    _db.SaveChanges();
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
        public void Edit(FinParty finParty)
        {
            using (var context = _db.Database.BeginTransaction())
            {
                try
                {
                    var existingRecord = _db.FinParties.Find(finParty.Id);
                    if (existingRecord != null)
                    {
                        var contactType = ("DELETE FROM CustomerContacts WHERE PartyId = " + finParty.Id);
                        _db.Database.ExecuteSqlCommand(contactType);
                        var brand = ("DELETE FROM CustomerBrands WHERE PartyId = " + finParty.Id);
                        _db.Database.ExecuteSqlCommand(brand);
                        var cert = ("DELETE FROM CustomerCertifications WHERE PartyId = " + finParty.Id);
                        _db.Database.ExecuteSqlCommand(cert);
                        var person = ("DELETE FROM CustomerContactPersons WHERE PartyId = " + finParty.Id);
                        _db.Database.ExecuteSqlCommand(person);
                        var machine = ("DELETE FROM CustomerMachines WHERE PartyId = " + finParty.Id);
                        _db.Database.ExecuteSqlCommand(machine);
                        var social = ("DELETE FROM CustomerSocials WHERE PartyId = " + finParty.Id);
                        _db.Database.ExecuteSqlCommand(social);
                        var special = ("DELETE FROM CustomerInstructions WHERE PartyId = " + finParty.Id);
                        _db.Database.ExecuteSqlCommand(special);

                        existingRecord.Active = finParty.Active;
                        existingRecord.City = finParty.City;
                        existingRecord.CityCode = finParty.CityCode;
                        existingRecord.CoaL5 = finParty.CoaL5;
                        existingRecord.CompanyName = finParty.CompanyName;
                        existingRecord.CountryCode = finParty.CountryCode;
                        existingRecord.CreatedBy = finParty.CreatedBy;
                        existingRecord.CreatedOn = finParty.CreatedOn;
                        existingRecord.CustomerBrands = finParty.CustomerBrands;
                        existingRecord.CustomerCertifications = finParty.CustomerCertifications;
                        existingRecord.CustomerContactPerson = finParty.CustomerContactPerson;
                        existingRecord.CustomerContactType = finParty.CustomerContactType;
                        existingRecord.CustomerMachineses = finParty.CustomerMachineses;
                        existingRecord.CustomerSocials = finParty.CustomerSocials;
                        existingRecord.CustomerSpecialInstructions = finParty.CustomerSpecialInstructions;
                        existingRecord.DispatchAddress = finParty.DispatchAddress;
                        existingRecord.EmailAddress = finParty.EmailAddress;
                        existingRecord.Fax = finParty.Fax;
                        existingRecord.FinVoucherDetails = finParty.FinVoucherDetails;
                        existingRecord.GlCode = finParty.GlCode;
                        existingRecord.GstNo = finParty.GstNo;
                        existingRecord.IsAgent = finParty.IsAgent;
                        existingRecord.IsBuyer = finParty.IsBuyer;
                        existingRecord.IsCust = finParty.IsCust;
                        existingRecord.IsDomestic = finParty.IsDomestic;
                        existingRecord.IsInternational = finParty.IsInternational;
                        existingRecord.IsSeller = finParty.IsSeller;
                        existingRecord.MailingAddress = finParty.MailingAddress;
                        existingRecord.ModifiedBy = finParty.ModifiedBy;
                        existingRecord.ModifiedOn = finParty.ModifiedOn;
                        existingRecord.NtnNo = finParty.NtnNo;
                        existingRecord.Phone = finParty.Phone;
                        existingRecord.Title = finParty.Title;
                        existingRecord.WebPage = finParty.WebPage;
                        _db.Entry(existingRecord).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();
                        context.Commit();
                    }
                }
                catch (Exception e)
                {
                    context.Rollback();
                    throw e;
                }
            }
        }
        public bool IsDuplicate(FinParty finParty)
        {

            if (finParty.Id == 0)
            {
                return _db.FinParties.Any(x => x.Title == finParty.Title);
            }

            if (finParty.Id != 0)
            {
                FinParty reg = _db.FinParties.FirstOrDefault(x => x.Title == finParty.Title);
                if (reg != null && reg.Id != finParty.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int id)
        {
            var existingRecord = _db.FinParties.Find(id);

            if (existingRecord != null)
            {
                _db.FinParties.Remove(existingRecord);
            }

            if (_db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            };
        }

        public FinParty FindById(int id)
        {
            FinParty finParty = _db.FinParties.Find(id);
            return finParty;
        }
        public IEnumerable<FinParty> GetAllParties()
        {
            return _db.FinParties.ToList();
        }
    }
}
