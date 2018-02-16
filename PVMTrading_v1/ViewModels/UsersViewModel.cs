using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class UsersViewModel
    {
        public ApplicationUser Users { set; get; }
        public List<string> Roles { set; get; }
    }
}