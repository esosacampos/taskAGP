//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api_Task.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TASK
    {
        public int task_id { get; set; }
        public string title_task { get; set; }
        public string description_task { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public string priority_level { get; set; }
    }
}
