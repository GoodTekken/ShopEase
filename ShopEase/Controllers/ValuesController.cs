using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopEase.DB;
using SQLitePCL;
using System;
using System.Net.Cache;

namespace ShopEase.Controllers
{
    //[Route("api/[controller]")]  //默认路径，网络请求路径为api/controller文件名，如果有多个方法则会冲突
    //[Route("[controller]")]      //仿照其他文件的路由格式
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ORMContext _context;

        public ValuesController(ORMContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 简单的网络请求测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string WebApiTest()
        {
            return "Hello World!";
        }

        /// <summary>
        /// 多方法名测试
        /// </summary>
        /// <param name="str1">字符串1</param>
        /// <param name="str2">字符串2</param>
        /// <returns></returns>
        [HttpGet]   
        public string WebApiTest2(string str1, string str2)
        {
            return "Hello World2!" + str1 + str2;
        }

        /// <summary>
        /// 随机在数据库增加五条数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Student> AddStudent()
        {
            for (var i = 0; i < 5; i++)
            {
                _context.Students.Add(new Student()
                {
                    Age = Random.Shared.Next(18, 25), // 生成18到24之间的随机年龄
                    Name = "Lily" + i,
                    Sex = Random.Shared.Next(2) == 0 ? "男" : "女" // 50%概率生成男性或女性
                });
            }

            _context.SaveChanges(); // 和缓存同步，更新数据库

            var res = _context.Students.ToList(); // 返回所有数据

            return res;
        }

        /// <summary>
        /// 显示数据库中的所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ShowStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }


        /// <summary>
        /// 根据ID号删除对应数据库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var studentToDelete = _context.Students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
                return Ok("Student with ID " + id + " deleted successfully.");
            }
            else
            {
                return NotFound("Student with ID " + id + " not found.");
            }
        }

        /// <summary>
        /// 根据ID号，更新数据库信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        /// <param name="newAge"></param>
        /// <param name="newSex"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpdateStudent(int id, string newName, int newAge, string newSex)
        {
            var studentToUpdate = _context.Students.FirstOrDefault(s => s.Id == id);
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = newName;
                studentToUpdate.Age = newAge;
                studentToUpdate.Sex = newSex;
                _context.SaveChanges();
                return Ok("Student with ID " + id + " updated successfully.");
            }
            else
            {
                return NotFound("Student with ID " + id + " not found.");
            }
        }
    }
}
