using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VncClassManager
{
    public static class SmtpKey
    {
        public const string err = "provide email and sendinblue smtp key and then change from static to const @ VncClassManager\\SmtpKey.cs";
        public static string MAIL => throw new Exception(err);
        public static string SMTPKEY => throw new Exception(err);
    }
}
