using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.Enum
{
            public enum GenderEnum
            {
                Male,
                Female
            }

            public enum GradeEnum
            {
                NIL,
                F,
                E,
                D,
                C,
                B,
                A,
                
            }

            public enum StateEnum
            {
                Abia,
                Adamawa,
                [Display(Name = "Akwa Ibom")]
                AkwaIbom,
                Bauchi,
                Bayelsa,
                Benue,
                Borno,
                [Display(Name = "Cross River")]
                CrossRiver,
                Delta,
                Ebonyi,
                Enugu,
                Edo,
                Ekiti,
                Gombe,
                Imo,
                Jigawa,
                Kaduna,
                Kano,
                Katsina,
                Kebbi,
                Kogi,
                Kwara,
                Lagos,
                Nasarawa,
                Niger,
                Ogun,
                Ondo,
                Osun,
                Oyo,
                Plateau,
                Rivers,
                Sokoto,
                Taraba,
                Yobe,
                Zamfara

            }
}
