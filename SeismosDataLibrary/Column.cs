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
    
    public partial class Column
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Column()
        {
            this.ColumnValues = new HashSet<ColumnValue>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.Guid KGraphDataId { get; set; }
        public System.Guid ACGraphDataId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColumnValue> ColumnValues { get; set; }
        public virtual KGraphData KGraphData { get; set; }
        public virtual ACGraphData ACGraphData { get; set; }
    }
}
