using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using _2._2_dars.Models;

namespace _2._2_dars.Service;

public class TestService
{
    private string testFilePath;
    
    private List<Test> tests;

    public TestService()
    {
        testFilePath = "/Users/macbook/GitHub/2.2_dars/Data/tests.json";

        if (File.Exists(testFilePath))
        {
            File.WriteAllText(testFilePath, "[]");
        }
        
    }

    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        var tests = GetTests();
        tests.Add(test);
        SaveData(tests);
        return test;
    }

    public bool DeleteTest(Guid testId)
    {
        var tests = GetTests();
        var testFromDb = GetById(testId);
        if (testFromDb is null)
        {
            return false;
        }
        tests.Remove(testFromDb);
        SaveData(tests);
        return true;
    }
    public bool UpdateTest(Guid testId)
    {
        var tests = GetTests();
        var testFromDb = GetById(testId);
        if (testFromDb is null)
        {
            return false;
        }
        var index = tests.IndexOf(testFromDb);
        tests[index] = testFromDb;
        return true;
    }
    public bool DeleteAllTests()
    {
        var tests = GetTests();
        tests.Clear();
        SaveData(tests);
        return true;
    }
    
    public Test GetById(Guid testId)
    {
        var tests = GetTests();
        foreach (var element in tests)
        {
            if (element.Id == testId)
            {
                return element;
            }
        }

        return null;
    }
    public List<Test> GetTests()
    {
        var tests = File.ReadAllText(testFilePath);
        return JsonSerializer.Deserialize<List<Test>>(tests);
    }
    
    public void SaveData(List<Test> tests)
    {
        var testJson = JsonSerializer.Serialize(tests);
        File.WriteAllText(testFilePath, testJson);
    }
    
}