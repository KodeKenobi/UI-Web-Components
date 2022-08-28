using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicyManagementDataAccess.Context;
using PolicyManagementSystem.Controllers.Models;
using AutoMapper;

namespace PolicyManagementSystem.Helper
{
    public class PolicyApplicationMapper : Profile
    {
        public PolicyApplicationMapper()
        {
            CreateMap<PolicyApplicationViewModel,MemberGroup>();
        }
    }
}
