// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using HangmanOnConsole;

Console.WriteLine("ADAM ASMACA");
Console.WriteLine("Merhaba");
int gameStyle = Helper.AskOption("Oynanış Tercihi Yapınız",["Tek Oyunculu","Çok Oyunculu"]);


if (gameStyle == 1)
{
    string choosenWord = Helper.ChooseWord();
    List<char> correctLetters = new List<char>();
    List<char> incorrectLetters = new List<char>();
    int counter = 0;

    while (true)
    {
        Console.Clear();
        Helper.DrawMan(counter);
        Console.WriteLine("\n\n");
        Helper.WriteSecretly(choosenWord, correctLetters);
        Console.WriteLine("\n\n");
        Console.WriteLine($"Yanlış Tahminler: {string.Join(" ",incorrectLetters)}");
        Console.Write("Bir harf veya kelime tahmin et: ");
        var input = Console.ReadLine();

        if (input.Length > 1)
        {
            if (input.ToLower() == choosenWord)
            {
                Console.Clear();
                Console.WriteLine("Tebrikler Doğru Tahmin. Kazandınız");
                break;
            }

            if (input.ToLower() != choosenWord)
            {
                Console.WriteLine("Yanlış kelime tahmini.");
                counter++;
                Thread.Sleep(1500);
            }
        }

        if (input.Length == 1)
        {
            if (Helper.CheckItHave(input, choosenWord)==true)
            {
                correctLetters.Add(input[0]);
            }

            if (Helper.CheckItHave(input, choosenWord) == false)
            {
                incorrectLetters.Add(input[0]);
                counter++;
            }
        }
        if (counter == 6)
        {
            Console.WriteLine("Bütün tahmin haklarını kullandınız. Kaybettiniz.");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine($"Doğru kelime '{choosenWord}' olacaktı.");
            Console.WriteLine("Oyunu sonlandırmak için bir tuşa basınız.");
            Console.ReadKey();
            break;
        }
        bool allCorrect = true;

        foreach (char c in choosenWord)
        {
            if (!correctLetters.Contains(c))
            {
                allCorrect = false;
            }
        }

        if (allCorrect == true)
        {
            Console.Clear();
            Console.WriteLine("Tebrikler Kazandınız.");
            break;
        }
        
    }
    
    
    
}
else if (gameStyle == 2)
{
    Console.Write("Kelime Gir: ");
    string inputWord = Console.ReadLine();
    List<char> correctLetters = new List<char>();
    List<char> incorrectLetters = new List<char>(); 
    int counter = 0;

    while (true)
    {
        Console.Clear();
        Helper.DrawMan(counter);
        Console.WriteLine("\n\n");
        Helper.WriteSecretly(inputWord, correctLetters);
        Console.WriteLine($"\nYanlış tahminler: {string.Join(" ",incorrectLetters)}");
        Console.WriteLine($"Doğru Tahminler: {string.Join(" ",correctLetters)}");
        Console.Write("\nBir harf ya da kelime tahmin et: ");
        var guess = Console.ReadLine().ToLower();
        
        if (guess.Length > 1)
        {
            if (guess.ToLower() == inputWord)
            {
                Console.WriteLine("Tebrikler doğru tahmin.");
                break; 
            }
            if (guess.ToLower() != inputWord)
            {
                Console.WriteLine("Yanlış kelime tahmini!");
                counter++;
                Console.ReadKey();
            }
        }
        else if (guess.Length == 1)
        {
            if (Helper.CheckItHave(guess, inputWord) == true)
            {
                correctLetters.Add(char.Parse(guess));
                
            }
            else if (Helper.CheckItHave(guess, inputWord) == false)
            {
                counter++;
                incorrectLetters.Add(char.Parse(guess));
                Console.WriteLine("Yanlış harf tahmini!");
            }
        }

        if (counter == 6)
        {
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("Bütün tahmin haklarını kullandınız. Kaybettiniz.");
            break;
        }

        bool allCorrect = true;

        foreach (char c in inputWord)
        {
            if (!correctLetters.Contains(c))
            {
                allCorrect = false;
            }
        }

        if (allCorrect == true)
        {
            Console.Clear();
            Console.WriteLine("Tebrikler Kazandınız.");
            break;
        }
    }
}