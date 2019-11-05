using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.IRepositories.CommonIRepositories.CommonParty;
using ERP.Core.Models.Common.Party;

namespace ERP.Infrastructure.Repositories.Common.PatryCommon
{
    public class SocialRepository : ISocialRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();

        public void Add(Social social)
        {
            _db.Social.Add(social);
            _db.SaveChanges();
        }

        public void Edit(Social modifiedSocials)
        {
			 var existingSocials = _db.Social.Find(modifiedSocials.Id);
            if(existingSocials!=null)
            {
                existingSocials.Detail = modifiedSocials.Detail;
                _db.Entry(existingSocials).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public bool Remove(int id)
        {
            var existingSocials = _db.Social.Find(id);

            if (existingSocials != null)
            {
                _db.Social.Remove(existingSocials);
            }

            if (_db.SaveChanges() == 1)
            {
                return true;

            }
            else
            {
                return false;
            }
            ;
        }

        public Social FindById(int id)
        {
            var social = _db.Social.Find(id);
            return social;
        }
 public bool IsDuplicate(Social social)
        {

            if (social.Id == 0)
            {
                return _db.Social.Any(x => x.Detail == social.Detail);
            }

            if (social.Id != 0)
            {
                Social reg = _db.Social.FirstOrDefault(x => x.Detail == social.Detail);
                if (reg != null && reg.Id != social.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public IEnumerable<Social> GetAllSocials()
        {
            IEnumerable<Social> social = _db.Social.ToList();
            return social;
        }
    }

}