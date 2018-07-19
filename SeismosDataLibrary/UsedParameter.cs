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
    
    public partial class UsedParameter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsedParameter()
        {
            this.UsedFilters = new HashSet<UsedFilter>();
            this.ParamConstraints = new HashSet<ParamConstraint>();
        }
    
        public System.Guid Id { get; set; }
        public double Viscosity { get; set; }
        public double BulkModulus { get; set; }
        public double FluidCompressibility { get; set; }
        public int NumberOfFractures { get; set; }
        public double FractureWidth { get; set; }
        public double Permeability { get; set; }
    
        public virtual Processing Processing { get; set; }
        public virtual Reflection Reflection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsedFilter> UsedFilters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParamConstraint> ParamConstraints { get; set; }
    }
}
