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
    
    public partial class Treatment
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public TreatmentTypeEnum Type { get; set; }
        public System.Guid WellId { get; set; }
    
        public virtual Well Well { get; set; }
    }
}
