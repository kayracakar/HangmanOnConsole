namespace HangmanOnConsole;

public class Helper
{
    public static int AskOption(string question, string[] options)
    {
        Console.WriteLine(question);

        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i+1}-{options[i]}");
        }
        
        Console.Write("Seçiminiz: ");
        return int.Parse(Console.ReadLine());
    }

    public static bool CheckItHave(string inputLetter, string inputWord)
    {
        
        foreach (var letter in inputWord)
        {
            if (letter == char.Parse(inputLetter))
            {
                return true;
            }
        }
        return false;
    }

    public static void DrawMan(int number)
    {
        string[] output = new string[]
        {
            "   O   ",  
            "    \\ ", 
            "   |",  
            "  /",  
            "\n    \\",  
            "  /"  
        };

        for (int i = 0; i < number; i++)
        {
            if (i < 1)
            {
                Console.WriteLine(output[i]);
            }

            if (i >= 1 && i < 4)
            {
                Console.Write($"\r{output[i]}");
            }

            if (i >= 4)
            {
                
                Console.Write($"\r{output[i]}");
            }
        }
    }

    public static void WriteSecretly(string input, List<char> correctLetters)
    {
        foreach (var letter in input)
        {
            if (correctLetters.Contains(letter))
            {
                Console.Write(letter+ " ");
            }
            else
            {
                Console.Write("_ ");
            }
        }
    }
    
    

    public static string ChooseWord()
    {
        string[] words = File.ReadAllLines("turkishwords.txt");
        
        Random rnd = new Random();
        string randomWord = words[rnd.Next(words.Length)].ToLower();
        return randomWord;
    }
}
       
