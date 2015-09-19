using ACLHandy.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACLHandy.ViewModel
{
    public class RecordListViewModel : BasicViewModel
    {
        public String ClientCode { get; set; }

        public String JobCode { get; set; }

        public String TargetUser { get; set; }
    }
}
