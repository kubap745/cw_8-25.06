using System;

enum Gender
{
    M,
    F
}
struct Student
{
    public string Nazwisko;
    public int NrAlbumu;
    public double Ocena;
    public Gender Plec;
}
class Program
{
    static void Main(string[] args)
    {
        Student[] grupa = new Student[5];
        for (int i = 0; i < grupa.Length; i++)
        {
            Console.WriteLine($"Student {i + 1}:");
            WypelnijStudenta(ref grupa[i]);
        }
        Console.WriteLine("Informacje o studentach:");
        foreach (Student student in grupa)
        {
            WyswietlStudenta(student);
        }
        double srednia = ObliczSrednia(grupa);
        Console.WriteLine($"Łączna średnia ocen: {srednia}");
    }
    static void WypelnijStudenta(ref Student student)
    {
        Console.WriteLine("Podaj nazwisko studenta:");
        student.Nazwisko = Console.ReadLine();

        Console.WriteLine("Podaj numer albumu:");
        student.NrAlbumu = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj ocenę:");
        double ocena = double.Parse(Console.ReadLine());

        if (ocena < 2.0)
        {
            student.Ocena = 2.0;
        }
        else if (ocena > 5.0)
        {
            student.Ocena = 5.0;
        }
        else
        {
            student.Ocena = ocena;
        }

        Console.WriteLine("Podaj płeć (M/F):");
        string plecInput = Console.ReadLine().ToUpper();
        if (plecInput == "M")
        {
            student.Plec = Gender.M;
        }
        else if (plecInput == "F")
        {
            student.Plec = Gender.F;
        }
        else
        {
            Console.WriteLine("Niepoprawny format płci. Ustawiam domyślnie na M.");
            student.Plec = Gender.M;
        }
    }
    static double ObliczSrednia(Student[] grupa)
    {
        double sumaOcen = 0.0;

        foreach (Student student in grupa)
        {
            sumaOcen += student.Ocena;
        }

        return sumaOcen / grupa.Length;
    }
    static void WyswietlStudenta(Student student)
    {
        Console.WriteLine($"Nazwisko: {student.Nazwisko}, Nr albumu: {student.NrAlbumu}, Ocena: {student.Ocena}, Płeć: {student.Plec}");
    }

}