//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestioBusCrud.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horari
    {
        public int id { get; set; }
        public int idParada { get; set; }
        public int idLinia { get; set; }
        public System.TimeSpan hora { get; set; }
        public Nullable<byte> direccio { get; set; }
        public int tipus { get; set; }
        public System.DateTime dataIniciVigent { get; set; }
        public System.DateTime dataFinalVigent { get; set; }
    
        public virtual Parada Parada { get; set; }
        public virtual Linia Linia { get; set; }
    }
}
