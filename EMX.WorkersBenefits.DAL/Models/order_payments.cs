//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMX.WorkersBenefits.DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class order_payments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order_payments()
        {
            this.orders = new HashSet<order>();
        }
    
        public int payment_id { get; set; }
        public int credit_card_type { get; set; }
        public string cerdit_card_number { get; set; }
        public string credit_card_exp_date { get; set; }
        public string credit_card_cvv { get; set; }
        public System.DateTime request_charge_date { get; set; }
        public int payment_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
