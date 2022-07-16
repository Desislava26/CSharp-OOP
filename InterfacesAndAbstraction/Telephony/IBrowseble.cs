using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowseble : ICallable
    {
        string Browsing(string website);
      
    }
}
