using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data.Entities
{
    /// <summary>
    /// According to the task subdirectories are not supported
    /// </summary>
    public class Directory
    {
        [Key]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }


        #region Relations

        public virtual ICollection<Record> Records { get; set; }

        #endregion



    }
}
