//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emelina_KS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Студенты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Студенты()
        {
            this.Дежурство = new HashSet<Дежурство>();
            this.Дежурство1 = new HashSet<Дежурство>();
            this.Отсутствующие = new HashSet<Отсутствующие>();
        }
    
        public int Код_студента { get; set; }
        public string Фамилия_студента { get; set; }
        public string Имя_студента { get; set; }
        public string Отчество_студента { get; set; }
        public string Группа { get; set; }
        public bool Первая_подгруппа { get; set; }
        public Nullable<int> Отдежурено_циклов { get; set; }
    
        public virtual Группы Группы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Дежурство> Дежурство { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Дежурство> Дежурство1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Отсутствующие> Отсутствующие { get; set; }
    }
}
