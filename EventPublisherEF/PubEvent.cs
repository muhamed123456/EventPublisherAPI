//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventPublisherEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class PubEvent
    {
        public int ID { get; set; }
        public int ID_Publisher { get; set; }
        public int ID_Event { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
