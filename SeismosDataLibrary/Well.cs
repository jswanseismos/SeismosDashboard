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
    
    public partial class Well
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Well()
        {
            this.Treatments = new HashSet<Treatment>();
            this.DataAcquisitions = new HashSet<DataAcquisition>();
        }
    
        public System.Guid Id { get; set; }
        public string WellName { get; set; }
        public WellGeometryEnum WellGeometryType { get; set; }
    
        public virtual SeismosProject SeismosProject { get; set; }
        public virtual DeviationSurvey DeviationSurveys { get; set; }
        public virtual WellBore WellBore { get; set; }
        public virtual Wellhead Wellhead { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treatment> Treatments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataAcquisition> DataAcquisitions { get; set; }
    }
}