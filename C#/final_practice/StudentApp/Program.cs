using System.IO;
using System.Collections.Generic;

public interface IGradable {
  double CalculateGpa();
}

public abstract class Student : IGradable {
  public string name {get; set;}
  public int id {get; set;}
  protected List<double> grades;

  public Student(string name, int id) {
    this.name = name;
    this.id = id;
    this.grades = new List<double>();
  }

  public void AddGrade(double grade) {
    this.grades.Add(grade);
  }
  
  // By declaring this abstract subclasses of Student
  // have to implement the method
  public abstract double CalculateGpa();
}


public class GradStudent : Student {
  public GradStudent(string name, int id) 
    : base(name, id)
  {
  }
  
  // If how Grad GPA changes the implementation can change
  // and not effect UnderGrad 
  public override double CalculateGpa() {
    double gpa = 0;
    for (int i = 0; i < this.grades.Count; i++) {
      gpa += this.grades[i];
    }

    if (this.grades.Count == 0) {
      return 0;
    }

    gpa /= this.grades.Count;
    return gpa;
  }
} 

public class UnderGradStudent : Student {
  public UnderGradStudent(string name, int id) : base(name, id)
  {
  }

  public override double CalculateGpa() {
    double gpa = 0;
    for (int i = 0; i < this.grades.Count; i++) {
      gpa += this.grades[i];
    }

    if (this.grades.Count == 0) {
      return 0;
    }

    gpa /= this.grades.Count;
    return gpa;
  }
}


class StudentManagement {
  public static void Main(string[] args) {
    var students = new List<Student>();
    int student_id = 1;

    string filename = args[0];

    using (StreamReader sr = new StreamReader(filename)) {
      string? line;

      while ((line = sr.ReadLine()) != null) {
        string[] data = line.Split(',');
        if (data[0] == "U") {
          UnderGradStudent Utemp = new UnderGradStudent(data[1], student_id++);
          for (int i = 2; i < data.Length; i++) {
            if (double.TryParse(data[i], out double grade)) {
              Utemp.AddGrade(grade);
            } else {
              Console.WriteLine($"Failed to parse grade {data[i]}");
            }
          }

          students.Add(Utemp);
          
        }

        if (data[0] == "G") {
          GradStudent Gtemp = new GradStudent(data[1], student_id++);
          for (int i = 2; i < data.Length; i++) {
            if (double.TryParse(data[i], out double grade)) {
              Gtemp.AddGrade(grade);
            } else {
              Console.WriteLine($"Failed to parse grade {data[i]}");
            }
          }

          students.Add(Gtemp);
        }
      }

      foreach (var student in students) {
        Console.WriteLine($"{student.id}  Name: {student.name}   GPA: {student.CalculateGpa()}");
      }
    }

  }
}
