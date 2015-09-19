using ACLHandy.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ACLHandy.ViewModel
{
    public class RecordListViewModel : BasicViewModel
    {
        public String ClientCode { get; set; }

        public String JobCode { get; set; }

        public String TargetUser { get; set; }

        public String ACLCheckResult { get; set; }

        public RecordListViewModel()
        {
            ACLCheckResult = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffA fixed-width column is a column that cannot be resized by mouse dragging or double-clicks. You can find instances in outlook. Currently two methods can be used to achieve the effect. One is to restyle GridViewColumnHeader to remove the gripper inside its Template. The other is to subclass GridViewColumn to restrict columns' width to a fixed size. Today's topic is about the second solution. The resulting column is a little bit different from the restyling one because there is still a gripper inside GridViewColumnHeader. When mouse is over the gap between columns, the cursor is still changed to the resizing cursor.";
        }

        public void SearchCurrentState(int ms)
        {
            Thread.Sleep(ms);
            ACLCheckResult = DateTime.Now.ToShortTimeString()+" "+ms;
            base.OnPropertyChanged("ACLCheckResult");
        }
    }
}
