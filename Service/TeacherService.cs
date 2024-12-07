using System.Text.Json;
using _2._2_dars.Models;

namespace _2._2_dars.Service;

public class TeacherService
{
    private string teacherFilePath;

    public TeacherService()
    {
        teacherFilePath = "/Users/macbook/GitHub/2.2_dars/Data/teachers.json";

        if (File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }
    }

    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        var teachers = GetTeachers();
        teachers.Add(teacher);
        SaveData(teachers);
        return teacher;
    }

    public bool DeleteTeacher(Guid teacherId)
    {
        var teachers = GetTeachers();
        var teacherFromDb = GetById(teacherId);
        if (teacherFromDb is null)
        {
            return false;
        }
        teachers.Remove(teacherFromDb);
        SaveData(teachers);
        return true;
    }

    public bool UpdateTeacher(Guid teacherId)
    {
        var teachers = GetTeachers();
        var teacherFromDb = GetById(teacherId);
        if (teacherFromDb is null)
        {
            return false;
        }
        var index = teachers.IndexOf(teacherFromDb);
        teachers[index] = teacherFromDb;
        SaveData(teachers);
        return true;
    }

    public Teacher GetById(Guid teacherId)
    {
        var teachers = GetTeachers();
        foreach (var element in teachers)
        {
            if (element.Id == teacherId)
            {
                return element;
            }
        }
        return null;
    }
    private void SaveData(List<Teacher> teachers)
    {
        var teacherJson = JsonSerializer.Serialize(teachers);
        File.WriteAllText(teacherFilePath, teacherJson);
        
    }
        
    public List<Teacher> GetAllTeachers()
    {
       return GetTeachers();   
    }

    private List<Teacher> GetTeachers()
    {
       var teachersJson = File.ReadAllText(teacherFilePath);
       var teachers= JsonSerializer.Deserialize<List<Teacher>>(teachersJson);
       return teachers;
    }
    
}