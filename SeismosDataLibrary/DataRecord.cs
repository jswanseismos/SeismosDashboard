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
    
    public partial class DataRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataRecord()
        {
            this.TimePicks = new HashSet<TimePick>();
            this.Reflections = new HashSet<Reflection>();
        }
    
        public long Id { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
        public double Seconds { get; set; }
        public System.DateTime StartTime { get; set; }
        public long SampleRate { get; set; }
        public System.Guid DataAcquisitionId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimePick> TimePicks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reflection> Reflections { get; set; }
        public virtual DataAcquisition DataAcquisition { get; set; }
    }
}
