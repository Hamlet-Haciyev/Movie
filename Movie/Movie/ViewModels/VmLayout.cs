using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmLayout
    {
        public Setting Setting { get; set; }

        public VmLogin VmLogin { get; set; }
        public VmRegister VmRegister { get; set; }
        public VmForgetPassword VmForgetPassword { get; set; }
    }
}
