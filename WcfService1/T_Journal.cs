//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService1
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Journal
    {
        public int ID_journal { get; set; }
        public int ID_book { get; set; }
        public int ID_reader { get; set; }
        public System.DateTime Date_issue { get; set; }
    
        public virtual T_Book T_Book { get; set; }
        public virtual T_Reader T_Reader { get; set; }
    }
}
