//1
string PrumernaRychlost(double km, double minuty)
{
    if (km < 0 || minuty < 0)
    {
        return "Neplatné hodnoty";
    }
    if (minuty == 0)
    {
        if (km > 0)
        {
            return "Nelze vypočítat (dělení nulou)";
        }
        else
        {
            return "Průměrná rychlost: 0,00 km/h";
        }
    }
    double hodiny = minuty / 60.0;
    double rychlost = km / hodiny;

    return "Průměrná rychlost: " + rychlost.ToString("0.00") + " km/h";
}
//2
int PocetSamohlasek(string text)
{
    if (string.IsNullOrEmpty(text))
    {
        return 0;
    }
    string samohlasky = "aeiouyáéěíóúůý";
    text = text.ToLower();
    int pocet = 0;
    for (int i = 0; i < text.Length; i++)
    {
        char c = text[i];
        if (samohlasky.Contains(c))
        {
            pocet++;
        }
    }
    return pocet;
}
//3
List<int> ZpracujPole(int[] pole)
{
    if (pole == null)
    {
        return new List<int>();
    }
    List<int> list = new List<int>();

    for (int i = 0; i < pole.Length; i++)
    {
        int cislo = pole[i];

        if (cislo >= 0 && !list.Contains(cislo))
        {
            list.Add(cislo);
        }
    }

    for (int i = 0; i < list.Count; i++)
    {
        for (int j = 0; j < list.Count - 1; j++)
        {
            if (list[j] > list[j + 1])
            {
                int temp = list[j];
                list[j] = list[j + 1];
                list[j + 1] = temp;
            }
        }
    }
    return list;
}