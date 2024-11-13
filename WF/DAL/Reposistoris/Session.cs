using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;

namespace WF.DAL.Reposistoris
{
    public static class Session
    {
        public static NhanVien LoggedInUser { get; set; }
    }
}
