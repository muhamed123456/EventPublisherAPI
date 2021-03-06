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
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Attendances = new HashSet<Attendance>();
            this.PubEvents = new HashSet<PubEvent>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int ID_City { get; set; }
        public int ID_Type { get; set; }
        public int ID_Place { get; set; }
        public System.DateTime StartEvent { get; set; }
        public System.DateTime EndEvent { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual City City { get; set; }
        public virtual Place Place { get; set; }
        public virtual Type Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PubEvent> PubEvents { get; set; }
    }
}
