using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarehouseInventory.Models.Entities
{
    [Table("Product")]
    public class ProductEntity : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }


    }
}