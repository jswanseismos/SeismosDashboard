//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeismosDataLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimePick
    {
        public long Id { get; set; }
        public TimePickTypeEnum Type { get; set; }
        public long SampleNumber { get; set; }
        public long DataRecordId { get; set; }
    
        public virtual DataRecord DataRecord { get; set; }
        public virtual Reflection StartReflection { get; set; }
        public virtual Reflection EndReflection { get; set; }
    }
}