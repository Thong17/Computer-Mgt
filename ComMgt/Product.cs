using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComMgt
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public Categories Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public string Photo { get; set; }
        public string Color { get; set; }
        public string Storage { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Battery { get; set; }
        public string Camera { get; set; }
        public string Accessibility { get; set; }
        public string Display { get; set; }
        public string Graphic { get; set; }
        public string Details { get; set; }
    }
}
