//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyApp.Infrastructure.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssetMetaData
    {
        public int AssetMetaDataID { get; set; }
        public string Value { get; set; }
        public Nullable<int> MetaDataID { get; set; }
        public Nullable<int> AssetID { get; set; }
    
        public virtual Asset Asset { get; set; }
        public virtual MetaData MetaData { get; set; }
    }
}