using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SmartLearn
 {
   public class OnlineCourse: Course
    {
        public int VideoDurationMinutes(get;set;}

        public string StreamUrl { get; private set;  }
       public OnlineCourse(string courseId,string title,string description,string instructorName,int maxStudents,int currentEnrollments,string category,int videoDurationMinutes,int streamUrl):base(courseId,title,description,instructorName,maxStudents,currentEnrollments,category,videoDurationMinutes,streamUrl)
        { }
    }
}
