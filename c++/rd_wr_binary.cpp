#include <fstream>
#include <iostream>
#include <memory>
using namespace std;

struct Student {
  int id;
  double gpa;
  char name[50];
};

struct MyStruct {
  int a;
  int b;
  double c;
  float d;
};

int main(int argc, char *argv[]) {
  if (argc != 2) {
    printf("Usage: %s <filename>\n", argv[0]);
    return 1;
  }

  string filename = argv[1];
  ofstream out(filename, ios::binary);

  Student temp = {0};
  int id = 1;
  int student_count = 5;

  cout << "Struct Student Size: " << sizeof(Student) << endl;
  cout << "Struct MyStruct Size: " << sizeof(MyStruct) << endl;
  cout << "Enter 5 Students information." << endl;
  cout << endl;

  for (int i = 0; i < student_count; i++) {
    temp.id = id++;
    cout << "Enter student " << i + 1 << " name > ";
    cin >> temp.name;
    cout << endl;

    cout << "Enter " << temp.name << " gpa > ";
    cin >> temp.gpa;
    cout << endl;

    out.write(reinterpret_cast<char *>(&temp), sizeof(Student));
  }
  out.close();

  ifstream fin(filename, ios::binary);

  for (int i = 0; i < student_count; i++) {
    fin.read(reinterpret_cast<char *>(&temp), sizeof(Student));
    cout << "ID: " << temp.id << " Name: " << temp.name << " GPA: " << temp.gpa
         << endl;
  }

  fin.close();

  return 0;
}
