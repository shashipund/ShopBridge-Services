//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductStoreServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ImageName { get; set; }
        public string Base64Content { get; set; }
    }
}
