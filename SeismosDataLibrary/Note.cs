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
    
    public partial class Note
    {
        public System.Guid Id { get; set; }
        public string Message { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.Guid> SourceId { get; set; }
        public string SourceDescription { get; set; }
        public string ProjectId { get; set; }
        public Nullable<System.Guid> SeismosProjectId { get; set; }
    
        public virtual SeismosProject SeismosProject { get; set; }
    }
}
