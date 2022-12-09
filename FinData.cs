using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtorinVladyslavPZ_32Exam.Resources
{
    public class FinData
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public double expenses { get; set; }

        public DateTime date { get; set; } = DateTime.Now;
        public string Categories { get; set; }
    }

    public enum Category
    {
        entertainment = 0,
        education = 1,
        clothing = 2,
        food = 3
    }
}
