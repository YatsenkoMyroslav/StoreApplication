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
    
    public partial class TTH
    {
        public int NUMBER_TTH { get; set; }
        public Nullable<int> NUMBER_CONTRACT { get; set; }
        public Nullable<int> PRODUCT_TYPE { get; set; }
        public int NUMBER_OF_PRODUCTS { get; set; }
        public int PRICE { get; set; }
        public Nullable<int> TRANSPORT_TYPE { get; set; }
        public Nullable<System.DateTime> DATE_OF_DEPARTURE { get; set; }
    
        public virtual CONTRACT CONTRACT { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual TRANSPORT TRANSPORT { get; set; }
    }
}