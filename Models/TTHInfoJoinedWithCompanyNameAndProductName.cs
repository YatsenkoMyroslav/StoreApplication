//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TTHInfoJoinedWithCompanyNameAndProductName
    {
        public int ID { get; set; }
        public string PRODUCT { get; set; }
        public int AMOUNT { get; set; }
        public Nullable<int> CONTRACT_NUMBER { get; set; }
        public string CUSTOMER { get; set; }
        public Nullable<int> SENT_BY { get; set; }
        public Nullable<System.DateTime> SENT_ON { get; set; }
    }
}
