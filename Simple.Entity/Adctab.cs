using System;
using System.Text;

namespace Simple.Entity
{
    [Serializable]
    public  class Adctab 
    {
       
        /// <summary>
        /// 
        /// </summary>
        public string AdcName{ get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public string AdcSex{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? AdcAge{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? AdcStatus{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Aid{ get; set; }
    }
}

