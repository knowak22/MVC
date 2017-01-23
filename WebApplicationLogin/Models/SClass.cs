﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationLogin.Models
{
    public class SClass
    {
        [ForeignKey("user")]
        public string SClassID { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        //zakomentowane w pierwszej wersji
        //public int SubjectID { get; set; }
        //public string StudentID { get; set; } 

        //wychowawca
        [Display(Name = "Wychowawca")]
        public string userID { get; set; }
        //public int TeacherID { get; set; } //wychowawca
        public virtual ApplicationUser user { get; set; }
        //public virtual ICollection<ApplicationUser> Users { get; set; }


        [Display(Name = "Lista przedmiotów:")]
        public int PlanID { get; set; }
        //public virtual ICollection<Subject> Subjects { get; set; }
        public virtual Plan Plan { get; set; }
    }
}