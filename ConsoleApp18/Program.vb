Imports System

Class Student
    Public Name As String
    Public RollNumber As Integer
    Public Grade As String

    Public Sub New(ByVal name As String, ByVal rollNumber As Integer, ByVal grade As String)
        Me.Name = name
        Me.RollNumber = rollNumber
        Me.Grade = grade
    End Sub

    Public Sub Display()
        Console.WriteLine($"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}")
    End Sub
End Class

Class Program
    Private Shared students As New List(Of Student)()

    Public Shared Sub Main(ByVal args As String())
        Dim choice As Integer

        Do
            Console.WriteLine("Menu:")
            Console.WriteLine("1. Add Student")
            Console.WriteLine("2. Update Student")
            Console.WriteLine("3. Delete Student")
            Console.WriteLine("4. Display Students")
            Console.WriteLine("5. Exit")
            Console.Write("Enter your choice: ")
            choice = Convert.ToInt32(Console.ReadLine())

            Select Case choice
                Case 1
                    AddStudent()
                Case 2
                    UpdateStudent()
                Case 3
                    DeleteStudent()
                Case 4
                    DisplayStudents()
                Case 5
                    Console.WriteLine("Exiting program.")
                    Exit Do
                Case Else
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.")
            End Select
        Loop While True
    End Sub

    Private Shared Sub AddStudent()
        Console.Write("Enter student name: ")
        Dim name As String = Console.ReadLine()
        Console.Write("Enter student roll number: ")
        Dim rollNumber As Integer = Convert.ToInt32(Console.ReadLine())
        Console.Write("Enter student grade: ")
        Dim grade As String = Console.ReadLine()

        Dim newStudent As New Student(name, rollNumber, grade)
        students.Add(newStudent)
        Console.WriteLine("Student added successfully.")
    End Sub

    Private Shared Sub UpdateStudent()
        If students.Count = 0 Then
            Console.WriteLine("No students to update.")
            Return
        End If

        Console.Write("Enter the roll number of the student to update: ")
        Dim rollNumber As Integer = Convert.ToInt32(Console.ReadLine())

        Dim foundStudent As Student = students.Find(Function(s) s.RollNumber = rollNumber)
        If foundStudent IsNot Nothing Then
            Console.Write("Enter updated grade: ")
            foundStudent.Grade = Console.ReadLine()
            Console.WriteLine("Student details updated successfully.")
        Else
            Console.WriteLine("Student not found.")
        End If
    End Sub

    Private Shared Sub DeleteStudent()
        If students.Count = 0 Then
            Console.WriteLine("No students to delete.")
            Return
        End If

        Console.Write("Enter the roll number of the student to delete: ")
        Dim rollNumber As Integer = Convert.ToInt32(Console.ReadLine())

        Dim foundIndex As Integer = students.FindIndex(Function(s) s.RollNumber = rollNumber)
        If foundIndex <> -1 Then
            students.RemoveAt(foundIndex)
            Console.WriteLine("Student deleted successfully.")
        Else
            Console.WriteLine("Student not found.")
        End If
    End Sub

    Private Shared Sub DisplayStudents()
        If students.Count = 0 Then
            Console.WriteLine("No students to display.")
        Else
            Console.WriteLine("Students:")
            For Each student As Student In students
                student.Display()
            Next
        End If
    End Sub
End Class