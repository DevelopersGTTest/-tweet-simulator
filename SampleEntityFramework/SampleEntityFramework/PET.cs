//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class PET
    {
        public int PET_ID { get; set; }
        public string PET_NAME { get; set; }
        public int AGE { get; set; }
        public int PET_TYPE_ID { get; set; }
    
        public virtual PET_TYPE PET_TYPE { get; set; }
    }
}