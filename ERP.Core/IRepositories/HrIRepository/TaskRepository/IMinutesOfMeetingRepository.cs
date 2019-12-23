using ERP.Core.Models.HR.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository.TaskRepository
{
    public interface IMinutesOfMeetingRepository
    {
        void Add(MinutesOfMeeting MinutesOfMeeting);
        void Edit(MinutesOfMeeting MinutesOfMeeting);
        bool Remove(MinutesOfMeeting MinutesOfMeeting);
        MinutesOfMeeting FindById(int id);
        IEnumerable<MinutesOfMeeting> GetAllMinutesOfMeeting();
    }
}
