using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP.Core.Models;

namespace VIGOR
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ERP.Core.Models.Finance.FinLedger, ERP.Core.Models.Finance.FinVoucherDetail>().ReverseMap();
        }
    }
}