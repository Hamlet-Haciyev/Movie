using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmForgetPasswordStatusForAjax
    {
        [DefaultValue(false)]
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
