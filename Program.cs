using System.Security;
using System.Threading.Channels;
using _2._2_dars.Models;
using _2._2_dars.Service;

namespace _2._2_dars;

class Program
{
   static void Main(string[] args)
    {
        TeacherService teacherService = new TeacherService();
        StudentService studentService = new StudentService();
        RunFrontEnd();
    }
    
    public static void RunFrontEnd()
    {
        TeacherService teacherService = new TeacherService();
        StudentService studentService = new StudentService();
        Console.WriteLine("1-Director");
        Console.WriteLine("2-Teacher");
        Console.WriteLine("3-Student");
        Console.WriteLine("4-Exit");
        Console.Write("Enter your choice:");
        var input = Console.ReadLine();
        if (input=="1")
        {
            Console.WriteLine("1-Add teacher");
            Console.WriteLine("2.Delete teacher");
            Console.WriteLine("3.Update teacher");
            Console.WriteLine("4.Get teacher");
            Console.WriteLine("5.Get All teachers");
            Console.Write("Enter: ");
            var input1 = Console.ReadLine();
            if (input1=="1")
            {
                var teacher = new Teacher();
                Console.Write("Enter first name:");
                teacher.FirstName = Console.ReadLine();
                Console.Write("Enter last name:");
                teacher.LastName = Console.ReadLine();
                Console.Write("age: ");
                teacher.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("enter likes: ");
                teacher.Likes =int.Parse(Console.ReadLine());
                Console.WriteLine("Enter gender: ");
                teacher.Gender = Console.ReadLine();
                Console.WriteLine("Enter dislikes: ");
                teacher.DisLikes = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter subject: ");
                teacher.Subject = Console.ReadLine();
                teacherService.AddTeacher(teacher);
                Console.WriteLine("Teacher added");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                RunFrontEnd();
                
            }

            if (input1=="2")
            {
                Console.Write("Enter teacher id:");
                var teacherId = Guid.Parse(Console.ReadLine());
                teacherService.DeleteTeacher(teacherId);
                Console.WriteLine("Teacher deleted");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                RunFrontEnd();
            }

            if (input1=="3")
            {
                Console.Write("Enter teacher id:");
                var teacherId = Guid.Parse(Console.ReadLine());
                teacherService.UpdateTeacher(teacherId);
                Console.WriteLine("Teacher updated");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                RunFrontEnd();
            }

            if (input1=="4")
            {
                Console.Write("Enter teacher id:");
                var teacherId = Guid.Parse(Console.ReadLine());
                var teacher = teacherService.GetById(teacherId);
                Console.WriteLine(teacher);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                RunFrontEnd();
            }

            if (input1=="5")
            {
                var teachersList = teacherService.GetAllTeachers();
                foreach (var teacher in teachersList)
                {
                    Console.WriteLine(teacher.Id);
                    Console.WriteLine(teacher.FirstName);
                    Console.WriteLine(teacher.LastName);
                    Console.WriteLine(teacher.Age);
                    Console.WriteLine(teacher.DisLikes);
                    Console.WriteLine(teacher.Likes);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    RunFrontEnd();
                    
                }
            }
            
        }

        if (input=="2")
        {
            var studentservice = new StudentService();
            Console.WriteLine("1-Add student");
            Console.WriteLine("2.Delete student");
            Console.WriteLine("3.Update student");
            Console.WriteLine("4.Get student");
            Console.Write("Enter");
            var input1 = Console.ReadLine();
            if (input1=="1")
            {
                var student = new Student();
                Console.WriteLine("Enter first name: ");
                student.FirstName= Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                student.LastName= Console.ReadLine();
                Console.WriteLine("Enter Age: ");
                student.Age= int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Degre: ");
                student.Degree = Console.ReadLine();
                Console.WriteLine("Gender: ");
                student.Gender = Console.ReadLine();
                studentservice.AddStudent(student);
                Console.WriteLine("Student added");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                RunFrontEnd();
            }
        }
        if (input=="3")
        {
            
            
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }
}