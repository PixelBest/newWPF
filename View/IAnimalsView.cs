using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newWPF.View
{
    internal interface IAnimalsView
    {
        string IdText { get; set; }
        string KindOfAnimalsText { get; set; }
        string NameText { get; set; }
        string AgeText { get; set; }
        string GenderText { get; set; }

        event EventHandler DeleteAnim;
        event EventHandler AddAnim;
        event EventHandler UpdateAnim;
        event EventHandler ClearAnim;
        event EventHandler CreateAnim;

        void LoadData();
        void ClearTextBox();
    }
}
