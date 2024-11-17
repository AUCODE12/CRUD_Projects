namespace g10;

internal class Program
{
    public static List<string> PassportSeries = new List<string>();
    public static void DataSeed()
    {
        PassportSeries.Add("AD8521478");
        PassportSeries.Add("AD4523698");
        PassportSeries.Add("AD7894563");
        PassportSeries.Add("AD9638521");
        PassportSeries.Add("AD7412589");
        PassportSeries.Add("AD3214589");
    }
    static void Main(string[] texts)
    {

        // CRUD => Create Read Update Delete
        DataSeed();
        StartFrontEnd();

    }

    public static void StartFrontEnd()
    {
        while (true)
        {
            Console.WriteLine("1. Add serie");
            Console.WriteLine("2. Delete serie");
            Console.WriteLine("3. Update serie");
            Console.WriteLine("4. Read serie");
            Console.Write("Choose : ");
            var option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter new serie : ");
                var passportSerie = Console.ReadLine();
                var index = AddSerie(passportSerie);
                if (index == -1)
                {
                    Console.WriteLine("Not added, error occured");
                }
                else
                {
                    Console.WriteLine($"Added, successed index : {index}");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter deleted serie : ");
                var passportSerie = Console.ReadLine();
                var boolResult = DeleteSerie(passportSerie);
                if (boolResult is true)
                {
                    Console.WriteLine("Deleted, successed");
                }
                else
                {
                    Console.WriteLine("Not deleted, error occured");
                }
            }
            else if (option == 3)
            {
                Console.Write("Enter old serie : ");
                var oldPassportSerie = Console.ReadLine();
                Console.Write("Enter updated serie : ");
                var newPassportSerie = Console.ReadLine();
                var boolResult = UpdateSerie(oldPassportSerie, newPassportSerie);
                if (boolResult is true)
                {
                    Console.WriteLine("Updated, successed");
                }
                else
                {
                    Console.WriteLine("Not update, error occured");
                }
            }
            else if (option == 4)
            {
                var series = GetPassportSeries();
                foreach (var serie in series)
                {
                    Console.WriteLine(serie);
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    public static int AddSerie(string serie)
    {
        var exists = PassportSeries.Contains(serie);
        var IsValidFormat = CheckSerieFormat(serie);

        if (exists is true || IsValidFormat is false)
        {
            return -1;
        }

        serie = serie.ToUpper();
        PassportSeries.Add(serie);

        return PassportSeries.Count - 1;
    }

    public static bool CheckSerieFormat(string serie)
    {
        var firstCheck = serie[0] == 'a' || serie[0] == 'A';
        var secondCheck = Char.IsLetter(serie[1]);
        var thirdCheck = serie.Length == 9;
        var fourthCheck = true;
        for (var i = 2; i < serie.Length; i++)
        {
            if (Char.IsDigit(serie[i]) is false)
            {
                fourthCheck = false;
                break;
            }
        }

        return firstCheck && secondCheck && thirdCheck && fourthCheck;
    }

    public static bool DeleteSerie(string serie)
    {
        var exists = PassportSeries.Contains(serie);
        PassportSeries.Remove(serie);
        return exists;
    }
    public static bool UpdateSerie(string oldSerie, string newSeria)
    {
        var index = PassportSeries.IndexOf(oldSerie);
        var boolResult = false;
        var IsValidFormat = CheckSerieFormat(newSeria);
        if (index < 0 || IsValidFormat is false)
        {
            return boolResult;
        }

        newSeria = newSeria.ToUpper();
        PassportSeries[index] = newSeria;
        boolResult = true;

        return boolResult;
    }

    public static List<string> GetPassportSeries()
    {
        return PassportSeries;
    }
}
