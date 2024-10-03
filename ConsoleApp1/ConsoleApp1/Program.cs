using System;
using System.Globalization;
using System.Threading.Channels;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the city or part of it!");
            string cityNameFromInput = Console.ReadLine();
            Console.WriteLine("Choose whether to display cities from an array or from a file.");
            Console.WriteLine("If from an array write \'array\', if from a file write \'file\'!");
            string method = Console.ReadLine();

            string letters = "";
            int matchingNames = 0;
            string wantedCity = "";

            if (method.Equals("array"))
            {
                string[] namesOfCities = new string[]
                {
                    "Benesov", "Beroun", "Bilina", "Blansko", "Bohumin",
                    "Boskovice", "Brandys", "Brno", "Bruntal", "Cernosice",
                    "Ceska Lipa", "Ceske Budejovice", "Cesky Krumlov", "Cheb", "Chomutov",
                    "Chrudim", "Decin", "Domazlice", "Frydek-Mistek", "Havlickuv Brod",
                    "Hodonin", "Hradec Kralove", "Hranice", "Jablonec", "Jicin",
                    "Jihlava", "Jirkov", "Kadan", "Karlovy Vary", "Kladno",
                    "Klatovy", "Kolin", "Kralupy", "Kromeriz", "Kutna Hora",
                    "Liberec", "Litomerice", "Litvinov", "Melnik", "Mlada Boleslav",
                    "Most", "Nachod", "Nymburk", "Olomouc", "Opava",
                    "Orlova", "Ostrava", "Pardubice", "Pelhrimov", "Pisek",
                    "Plzen", "Podebrady", "Police nad Metuji", "Praha", "Prerov",
                    "Pribram", "Prostejov", "Rakovnik", "Rokycany", "Roznov pod Radhostem",
                    "Rychnov nad Kneznou", "Semily", "Slany", "Sokolov", "Strakonice",
                    "Sumperk", "Svitavy", "Tabor", "Tachov", "Telc",
                    "Trutnov", "Turnov", "Usti nad Labem", "Usti nad Orlici", "Valasske Mezirici",
                    "Varnsdorf", "Vsetin", "Vyskov", "Zatec", "Zdar nad Sazavou",
                    "Zlin", "Znojmo", "Zruc nad Sazavou", "Breclav", "Vrchlabi",
                    "Stramberk", "Zelezny Brod", "Nachod", "Trebic", "Jesenik",
                    "Varnsdorf", "Bilina", "Kraluv Dvur", "Blatna", "Bystrice pod Hostynem",
                    "Kraslice", "Nachod", "Rajhrad", "Roudnice nad Labem", "Trebon"
                };

                for(int i = 0; i < namesOfCities.Length; i++)
                {
                    int sameLetter = 0;
                    for(int j = 0; j < cityNameFromInput.Length; j++)
                    {
                        // If the city name from the input have same letter like city name from the array, the program will count it
                        if (cityNameFromInput.ElementAtOrDefault(j).Equals(namesOfCities[i].ElementAtOrDefault(j)))
                        {
                            // Counting the same letters
                            sameLetter++;
                        }

                        // If if all the letters that have been entered match a city or cities, then either the name or the following letters are printed
                        if (sameLetter == cityNameFromInput.Length)
                        {
                            letters += namesOfCities[i].ElementAtOrDefault(j + 1);
                            // Matching city name
                            wantedCity = namesOfCities[i];
                            // If there is a matching city name, the program will count it
                            matchingNames++;
                        }
                    }
                }   
            } else if (method.Equals("file"))
            {
                string fileName = "C:\\Users\\jakub\\OneDrive\\Programování\\C#\\Projects\\Keyfilter\\ConsoleApp1\\ConsoleApp1\\cities.txt";
                StreamReader readFromFile = new StreamReader(fileName);
                string cityNameFromFile;

                while ((cityNameFromFile = readFromFile.ReadLine()) != null)
                {
                    int sameLetter = 0;
                    for (int i = 0; i < cityNameFromInput.Length; i++)
                    {
                        // If the city name from the input have same letter like city name from the file, the program will count it
                        if(cityNameFromInput.ElementAtOrDefault(i).Equals(cityNameFromFile.ElementAtOrDefault(i)))
                        {
                            // Counting the same letters
                            sameLetter++;
                        }

                        // If if all the letters that have been entered match a city or cities, then either the name or the following letters are printed
                        if (sameLetter == cityNameFromInput.Length)
                        {
                            letters += cityNameFromFile.ElementAtOrDefault(i + 1);
                            // Matching city name
                            wantedCity = cityNameFromFile;
                            // If there is a matching city name, the program will count it
                            matchingNames++;
                        }
                    }
                }

                readFromFile.Close();
            } else
            {   
                Console.WriteLine("You entered the wrong value!");
            }

            // If there is no matching city name, the program will display "Not found!", if there is one matching city name, the program will display the name of the city, if there are more matching city names, the program will display the letters of the city names in alphabetical order.
            switch (matchingNames)
            {
                case 0:
                    Console.WriteLine("Not found!");
                    break;
                case 1:
                    Console.WriteLine(wantedCity);
                    break;
                default:
                    // result is the letters of the city names in alphabetical order and without duplicates
                    string result = RemoveDuplicateLetters(SortCharactersAlphabetically(letters));
                    // It will print the result in uppercase
                    Console.WriteLine(result.ToUpper());
                    break;
            }
        }

        // Method for sorting letters in alphabetical order.
        static string SortCharactersAlphabetically(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Sort(charArray);          
            return new string(charArray);
        }

        // Method for removing duplicate letters.
        static string RemoveDuplicateLetters(string input)
        {
            string result = new string(input.Distinct().ToArray());
            return result;
        }

    }
}
