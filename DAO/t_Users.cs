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
    
    public partial class t_Users
    {
        public System.Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool IsEmailVerified { get; set; }
        public string MobileNumber { get; set; }
        public System.Guid ActivationCode { get; set; }
        public Nullable<System.Guid> PasswordResetToken { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
