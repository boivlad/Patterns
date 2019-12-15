using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_pattern
{
  public struct Student
  {
    private string Name;
    private int Rating;
    public Student(string name, int rating)
    {
      Name = name;
      Rating = rating;
    }
    public string GetName()
    {
      return Name;
    }
    public int GetRating()
    {
      return Rating;
    }
    public void RemoveStudent()
    {
      Name = "";
      Rating = 0;
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      View view = new View();
      view.AddNewStudent("Владислав", 95);
      view.AddNewStudent("Павел", 97);
      view.GetRatingByName("Владислав");
      view.RemoveStudent("Павел");
      view.GetRatingByName("Павел");
      Console.ReadKey();
    }
  }
  public class Model
  {
    public Student[] Students;
    public int storageSize;
    public Model()
    {
      Students = new Student[100];
      storageSize = 0;
    }
    public bool AddStudent(Student student)
    {
      Students[storageSize] = student;
      storageSize++;
      return true;
    }
    public int GetStudentsByName(string student)
    {
      for (int i = 0; i < storageSize; i++)
      {
        if (Students[i].GetName() == student)
        {
          return Students[i].GetRating();
        }
      }
      return -1;
    }
    public bool RemoveStudentByName(string student)
    {
      for (int i = 0; i < storageSize; i++)
      {
        if (Students[i].GetName() == student)
        {
          Students[i].RemoveStudent();
          return true;
        }
      }
      return false;
    }
  }
  public class Controller
  {
    public Model model;
    public Controller()
    {
      model = new Model();
    }
    public string NewStudent(string student, int rating)
    {
      Student newStudent = new Student(student, rating);
      if (model.AddStudent(newStudent))
      {
        return "Пользователь " + student + " успешно добавлен";
      }
      return "Пользователь не добавлен!";
    }
    public string GetStudentRating(string name)
    {
      int rating = model.GetStudentsByName(name);
      if (rating >= 0)
      {
        return "Оценка студента " + name  + " - " + rating + " баллов";
      }
      return "Студент не найден!";
    }
    public string RemoveStudent(string name)
    {
      if (model.RemoveStudentByName(name))
      {
        return "Студент " + name + " успешно исключён";
      }
      return "Данный студент не найден, возможно он был исключён ранее";
    }
  }
  public class View
  {
    public Controller controller;
    public View()
    {
      controller = new Controller();
    }

    public void AddNewStudent(string student, int rating)
    {
      Console.WriteLine(controller.NewStudent(student, rating));
    }
    public void GetRatingByName(string student)
    {
      Console.WriteLine(controller.GetStudentRating(student));
    } 
    public void RemoveStudent(string student)
    {
      Console.WriteLine(controller.RemoveStudent(student));
    }
    public static void print(string message)
    {
      Console.WriteLine(message);
    }
  }
  /*TODO:
   * Composite
   * Observer
   * Strategy
  */
}
