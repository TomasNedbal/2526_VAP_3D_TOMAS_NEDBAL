
//StreamWriter zapíše do souboru výstup
//Umožňuje zapisovat postupně, aniž by bylo nutné držet celý obsah v paměti
//alt File.WriteAllLines

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Chybi argumenty");
            return;
        }

        string vstup = args[0];
        string vystup = args[1];

        string[] radky = File.ReadAllLines(vstup);

        string[] vysledek = new string[radky.Length];

        for (int i = 0; i < radky.Length; i++)
        {
            string[] casti = radky[i].Split(' ');

            string predmet = casti[0];
            int soucet = 0;
            int pocet = 0;

            for (int j = 1; j < casti.Length; j++)
            {
                soucet = soucet + int.Parse(casti[j]);
                pocet = pocet + 1;
            }

            double prumer = (double)soucet / pocet;

            vysledek[i] = predmet + " " + prumer.ToString("0.00");
        }

        File.WriteAllLines(vystup, vysledek);

        Console.WriteLine("Hotovo");
    }
}