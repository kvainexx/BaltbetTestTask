using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data.Entities
{
    public class Record
    {
        [Key]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Value { get; set; }

        [Required]
        public bool IsFavorite { get; set; }


        #region Relations
        //[Required]
        public virtual Directory Directory { get; set; }

        #endregion



    }
}
