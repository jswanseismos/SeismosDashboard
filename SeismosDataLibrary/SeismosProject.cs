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
    
    public partial class SeismosProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeismosProject()
        {
            this.Wells = new HashSet<Well>();
            this.Notes = new HashSet<Note>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
        public string Pad { get; set; }
        public string JobNum { get; set; }
        public string AFENum { get; set; }
        public string Formation { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public System.Guid SeismosClientId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Well> Wells { get; set; }
        public virtual SeismosClient SeismosClient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Note> Notes { get; set; }
    }
}