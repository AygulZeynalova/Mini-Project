using MiniProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Models.Entities
{
    public class Model : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
       
    }
}
