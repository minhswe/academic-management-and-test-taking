//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExaminationSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionCorrectAnswer
    {
        public int ID { get; set; }
        public string QuestionID { get; set; }
        public string CorrectChoice { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
