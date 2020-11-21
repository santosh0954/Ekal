using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekal_App
{
    public static class Common
    {
        public static int UserProfileID { get; set; } = 1;
    }

    public enum EkaiTypes
    {
        Prabhag = 1,
        Sambhag,
        Bhag ,        
        Anchal ,
        Sanch ,
        Gram ,
    }
}
