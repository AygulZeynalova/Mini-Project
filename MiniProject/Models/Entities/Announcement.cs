using MiniProject.Entities.Enums;
using MiniProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Models.Entities
{
    public class Announcement :AuditableEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Categories categories { get; set; }
        public Gears gears { get; set; }
        public FuelTypes fuelTypes { get; set; }
        public Transmissions transmissions { get; set; }
        public int March { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        
        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }
       
    }
}
