using Microsoft.EntityFrameworkCore.Storage.Json;
using MiniProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Models.Entities
{
    public class Brand : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
}
