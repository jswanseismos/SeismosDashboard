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
    
    public partial class WellheadComponent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WellheadComponent()
        {
            this.Materials = new HashSet<Material>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public double InternalDiameter { get; set; }
        public double OuterDiameter { get; set; }
        public double Length { get; set; }
        public Nullable<System.Guid> WellheadAssemblyId { get; set; }
        public WellheadComponentEnum Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Materials { get; set; }
        public virtual WellheadAssembly WellheadAssembly { get; set; }
    }
}
