using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopEase
{
    public class Student
    {
        [Key] //主键
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自动递增
        public int Id { get; set; }

        public string Name { get; set;}

        public int Age { get; set;}
        
        public string Sex { get; set;}
    }
}
