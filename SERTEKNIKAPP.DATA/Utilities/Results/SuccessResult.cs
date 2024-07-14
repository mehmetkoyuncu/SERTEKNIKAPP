using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERTEKNIKAPP.DATA.Utilities.Results
{
    public class SuccessResult : Result
    {
        //Base = Result Class
        public SuccessResult(string message) : base(true, message) { }
        public SuccessResult() : base(true) { }
    }
}
