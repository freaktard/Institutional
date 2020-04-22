using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Institution.Models
{
    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {

    }

    public class StudentMetaData
    {
        [Display(Name = "Student ID") ]
        public int STUDENT_ID { get; set; }
        [Display(Name = "Name")]
        public string NAME { get; set; }
        [Display(Name = "Last Name")]
        public string LASTNAME { get; set; }
        [Display(Name = "Age")]
        public int AGE { get; set; }
        [Display(Name = "Course Name")]
        public int COURSE_ID { get; set; }
    }

}