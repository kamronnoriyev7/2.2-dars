using System.Text.Json;
using _2._2_dars.Models;

namespace _2._2_dars.Service;

public class StudentService
{
    private string studentFilePath;

    public StudentService()
    {
        studentFilePath= "/Users/macbook/GitHub/2.2_dars/Data/students.json";

        if (File.Exists(studentFilePath)is false)
        {
            
            File.WriteAllText(studentFilePath, "[]");
        }
    }
    
    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        var students = GetStudents();
        students.Add(student);
        SaveStudents(students);
        return student;
    }
    
    public bool DeleteStudent(Guid studentId)
    {
        var students = GetStudents();
        var studentFromDb = GetById(studentId);
        if (studentFromDb is null)
        {
            return false;
        }
        students.Remove(studentFromDb);
        SaveStudents(students);
        return true;
    }

    public bool UpdateStudent(Guid studentId)
    {
        var students = GetStudents();
        var studentFromDb = GetById(studentId);
        if (studentFromDb is null)
        {
            return false;
        }

        var index = students.IndexOf(studentFromDb);
        students[index] = studentFromDb;
        SaveStudents(students);
        return true;

    }
    
    

    private void SaveStudents(List<Student> students)
    {
        var studentJson = JsonSerializer.Serialize(students);
        File.WriteAllText(studentFilePath, studentJson);
    }

    private List<Student> GetStudents()
    {
        var studentsJson = File.ReadAllText(studentFilePath);
        var student = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return student;
    }
    
    public Student GetById(Guid studentId)
    {
        var students = GetStudents();
        foreach (var element in students)
        {
            if (element.Id == studentId)
            {
                return element;
            }
        }

        return null;
    }
    
    

   
}