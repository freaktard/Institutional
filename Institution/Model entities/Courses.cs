using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Institution.Models
{
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {

    }

    public class CourseMetaData
    {
        [Display(Name = "Course ID")]
        public int COURSE_ID { get; set; }
        [Display(Name = "Course name")]
        public string NAME { get; set; }
       
    
    }
}