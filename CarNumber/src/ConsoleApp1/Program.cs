namespace ConsoleApp1
{
    internal class Program
    {
        public static List<string> CarNumbers = new List<string>();
        public static void BeforeDateBase()
        {
            CarNumbers.Add("85A729AC");
            CarNumbers.Add("42B615ZT");
            CarNumbers.Add("19C472XY");
            CarNumbers.Add("67D894KL");
            CarNumbers.Add("24E583MN");
            CarNumbers.Add("11F627QR");
            CarNumbers.Add("39G893PT");
            CarNumbers.Add("88H245YU");
            CarNumbers.Add("53J174LO");
            CarNumbers.Add("90K381VX");
        }
        static void Main(string[] args)
        {
            //CRUD - Create, Read, Update, Delate (Check)
            // 85A729AC

            BeforeDateBase();
            RunApp();
        }
        public static void RunApp()
        {
            while (true)
            {
                Console.WriteLine("1. Add Car Number");
                Console.WriteLine("2. Read Car Number");
                Console.WriteLine("3. Update Car Number");
                Console.WriteLine("4. Delate Car Number");

                Console.Write("Choose Option: ");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.Write("Enter Car Number: ");
                    var carNumber = Console.ReadLine();
                    var index = AddCarNumber(carNumber);
                    if (index == -1)
                    {
                        Console.WriteLine("Not added");
                    }
                    else
                    {
                        Console.WriteLine("Added");
                    }
                }
                else if (option == 2)
                {
                    var read = ReadCarNumber();
                    foreach (var carNumber in read)
                    {
                        Console.WriteLine($"{carNumber} ");
                    }
                }
                else if (option == 3)
                {
                    Console.Write("Enter Old Car Number: ");
                    var oldCarNumber = Console.ReadLine();
                    Console.Write("Enter New Car Number: ");
                    var newCarNumber = Console.ReadLine();
                    var boolResult = UpdateCarNumber(oldCarNumber, newCarNumber);
                    if (boolResult is false)
                    {
                        Console.WriteLine("Not Updated");
                    }
                    else
                    {
                        Console.WriteLine("Updated");
                    }
                }
                else if (option == 4)
                {
                    Console.Write("Delete Car Number: ");
                    var carNumber = Console.ReadLine();
                    var boolReuslt = DeleteCarNumber(carNumber);
                    if (boolReuslt is false)
                    {
                        Console.WriteLine("Not Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Deleted");
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static int AddCarNumber(string carNumber)
        {
            var exists = CarNumbers.Contains(carNumber);
            var isCheck = CheckCarNumber(carNumber);
            if (exists is true || isCheck is false)
            {
                return -1;
            }
            carNumber = carNumber.ToUpper();
            CarNumbers.Add(carNumber);

            return CarNumbers.Count - 1;
        }
        public static List<string> ReadCarNumber()
        {
            return CarNumbers;
        }
        public static bool UpdateCarNumber(string oldCarNumber, string newCarNumber)
        {
            var index = CarNumbers.IndexOf(oldCarNumber);
            var isCheck = CheckCarNumber(newCarNumber);
            var boolResult = false;
            if (index < 0 || isCheck is false)
            {
                return boolResult;
            }
            newCarNumber = newCarNumber.ToUpper();
            CarNumbers[index] = newCarNumber;
            boolResult = true;

            return boolResult;
        }
        public static bool DeleteCarNumber(string carNumber)
        {
            var exists = CarNumbers.Contains(carNumber);
            CarNumbers.Remove(carNumber);
            return exists;
        }
        public static bool CheckCarNumber(string carNumber)
        {
            var firstCheck = carNumber.Substring(0, 2) == "85" || carNumber.Substring(0, 2) == "40" || carNumber.Substring(0, 2) == "30" || carNumber.Substring(0, 2) == "25" || carNumber.Substring(0, 2) == "20" || carNumber.Substring(0, 2) == "60" || carNumber.Substring(0, 2) == "70" || carNumber.Substring(0, 2) == "75" || carNumber.Substring(0, 2) == "80" || carNumber.Substring(0, 2) == "90" || carNumber.Substring(0, 2) == "95" || carNumber.Substring(0, 2) == "50" || carNumber.Substring(0, 2) == "10" || carNumber.Substring(0, 2) == "01";
            var secondCheck = Char.IsLetter(carNumber.Substring(2, 1)[0]) && Char.IsLetter(carNumber.Substring(carNumber.Length - 2, 1)[0]) && Char.IsLetter(carNumber.Substring(carNumber.Length - 1, 1)[0]);
            var thirdCheck = Char.IsDigit(carNumber.Substring(3, 1)[0]) && Char.IsDigit(carNumber.Substring(4, 1)[0]) && Char.IsDigit(carNumber.Substring(5, 1)[0]);
            var fourthCheck = carNumber.Length == 9;
        
            return firstCheck && secondCheck && thirdCheck && fourthCheck;
        }
    }
}


