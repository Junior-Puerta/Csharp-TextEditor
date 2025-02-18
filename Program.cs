using System;
using System.IO;

static void MainMenu()
{
    Console.Clear();
    Console.WriteLine("what do you want to do? ");
    Console.WriteLine("1 - Open a new file");
    Console.WriteLine("2 - Create a new file");
    Console.WriteLine("0 - Exit");

    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: OpenFile(); break;
        case 2: CreateFile(); break;
        default:
            Console.Clear();
            Console.WriteLine("Backing to Main Menu..");
            Thread.Sleep(1000);
            Console.Clear();
            MainMenu();
            break;
    }
}

static void OpenFile()
{
    Console.Clear();
    Console.WriteLine("Which is the file's path:");
    string path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }
    Console.WriteLine("");
    Console.ReadLine();
    MainMenu();

}

static void CreateFile()
{
    Console.Clear();
    Console.WriteLine("Enter your text bellow (Press Esc to exit): ");
    Console.WriteLine("----------------");
    string text = ""; //Para Armazenar o que o usuário escreve

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape); //enquanto o usuário não apertar esc
    Save(text);
}

static void Save(string text)
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("Which is the path to save the file?");
    var path = Console.ReadLine();//???.txt

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"File saved in directory {path} with success!");
    Console.ReadLine();
    MainMenu();
}
MainMenu();