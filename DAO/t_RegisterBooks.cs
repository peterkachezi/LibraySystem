//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_RegisterBooks
    {
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string BookNo { get; set; }
        public Nullable<System.Guid> LanguageId { get; set; }
        public string ISBN_No { get; set; }
        public string Edition { get; set; }
        public string Copies { get; set; }
        public Nullable<System.Guid> PublisherId { get; set; }
        public string PublishedYear { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
    
        public virtual t_Languages t_Languages { get; set; }
        public virtual t_Publishers t_Publishers { get; set; }
    }
}
