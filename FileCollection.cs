using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publisher
{
    class FileCollection : List<string>
    {
        public event EventHandler OnFillingList;
    

        public delegate void EventHandler(object sender, EventArgs e);

        public void Add(string s)
        {
            bool found = false;
            foreach (string str in this as FileCollection)
            {
                if (s == str)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                base.Add(s);
        }

        public void Clear()
        {
            base.Clear();
            OnFillingList(this, new EventArgs());
        }

        public void FillList()
        {
            OnFillingList(this, new EventArgs());
        }
    }
}
