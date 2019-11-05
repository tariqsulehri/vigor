using System.Collections.Generic;
using System.Linq;
using ERP.Core.IRepositories.CommonIRepositories;
using ERP.Core.Models.Common;

namespace ERP.Infrastructure.Repositories.Common
{
    public class StateRepository: IStateRepository
    {
        private readonly ErpDbContext _db = new ErpDbContext();
        public void Add(State state)
        {
            _db.State.Add(state);
            _db.SaveChanges();
        }
         public void Edit(State state)
        {
            var existingState = _db.State.Find(state.Id);

            if(existingState!=null)
            {
                existingState.Name = state.Name;
                existingState.Stcode = state.Stcode;
                existingState.CId = state.CId;
                _db.Entry(existingState).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
        public bool Remove(int scode)
        {
            var existingState = _db.State.Find(scode);

            if (existingState != null)
            {
                _db.State.Remove(existingState);
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
        public State FindById(int scode)
        {
            var state = _db.State.Find(scode);
            return state;
        }

       public bool IsDuplicate(State state)
        {

            if (state.Id == 0)
            {
                return _db.State.Any(x => x.Name == state.Name);
            }

            if (state.Id != 0)
            {
                State reg = _db.State.FirstOrDefault(x => x.Name == state.Name);
                if (reg != null && reg.Id != state.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<State> GetAllStates()
        {
            IEnumerable<State> states = _db.State.ToList();
            return states;
        }
    }

}
