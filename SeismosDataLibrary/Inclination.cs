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
    
    public partial class Inclination
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public System.Guid DeviationSurveyId { get; set; }
    
        public virtual DeviationSurvey DeviationSurvey { get; set; }
    }
}
