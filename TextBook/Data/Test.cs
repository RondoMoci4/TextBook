//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextBook.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            this.TestQuestion = new HashSet<TestQuestion>();
            this.TestResult = new HashSet<TestResult>();
        }
    
        public int IdTest { get; set; }
        public string Title { get; set; }
        public System.TimeSpan Time { get; set; }
        public int CountQuestion { get; set; }
        public int CreatorTest { get; set; }
        public string Description { get; set; }
    
        public virtual Autorization Autorization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestResult> TestResult { get; set; }
    }
}