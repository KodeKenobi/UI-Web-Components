using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PolicyManagementModels;
using PolicyManagementDataAccess.Context;
using Microsoft.AspNetCore.Identity;
namespace PolicyManagementDataAccess.Helpers
{
    //Library that transforms one object type to another object type
    public class PolicyManagementMapper: Profile //Inherits Automapper profile
    {
        public PolicyManagementMapper()
        {
            CreateMap<CreateAddressModel, Addresses>();
            
        }
    }
}
