using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DogSPA
{
    [Table("pets")]
    public class Pet
    {
        [PrimaryKey, AutoIncrement, Column("pet_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("race")]
        public string Race { get; set; }
        [Column("size")]
        public string Size { get; set; }
        [Column("birthday")]
        public DateTime Birthday { get; set; }
        [Column("pet_picture")]
        public string Picture { get; set; }
    }
}
