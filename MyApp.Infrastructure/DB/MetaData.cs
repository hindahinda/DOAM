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
    
    public partial class MetaData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MetaData()
        {
            this.AssetMetaDatas = new HashSet<AssetMetaData>();
            this.AssetTypeSupportedMetaDatas = new HashSet<AssetTypeSupportedMetaData>();
        }
    
        public int MetaDataID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MetaDataGroupID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetMetaData> AssetMetaDatas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetTypeSupportedMetaData> AssetTypeSupportedMetaDatas { get; set; }
        public virtual MetaDataGroup MetaDataGroup { get; set; }
    }
}
