using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopEase.DB
{
    public class ORMContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        
        public ORMContext()
        {
            this.Database.EnsureCreated();   //如果没有数据库，则自动创建数据库和数据表
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //数据库连接字符串
            optionsBuilder.UseSqlite("Data Source = ORM_Sqlite.db");
        }
    }

}
