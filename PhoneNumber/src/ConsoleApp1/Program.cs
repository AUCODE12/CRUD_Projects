namespace ConsoleApp1
{
    internal class Program
    {
        public static List<string> PhoneNumbers = new List<string>();
        public static void BeforeDataBase()
        {
            PhoneNumbers.Add("907390610");
            PhoneNumbers.Add("916390710");
            PhoneNumbers.Add("977397711");
            PhoneNumbers.Add("998390611");
            PhoneNumbers.Add("987390712");
            PhoneNumbers.Add("909390212");
            PhoneNumbers.Add("937391799");
            PhoneNumbers.Add("942390808");
            PhoneNumbers.Add("995390817");
            PhoneNumbers.Add("903390606");
        }
        static void Main(string[] args)
        {
            // CRUD - Add, Read, Update, Delate
            BeforeDataBase();
            RunApp();
        }

        public static void RunApp()
        {
            while (true)
            {
                Console.WriteLine("1. Add Phone Number");
                Console.WriteLine("2. Read Phone Number");
                Console.WriteLine("3. Update Phone Number");
                Console.WriteLine("4. Delate Phone Number");

                Console.Write("Choese Option: ");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.Write("Enter Phone Number: ");
                    var phoneNumber = Console.ReadLine();
                    var index = AddPhoneNumber(phoneNumber);
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
                    var read = ReadPhoneNumber();
                    foreach (var phoneNumber in read)
                    {
                        Console.WriteLine($"+998{phoneNumber} ");
                    }
                }
                else if (option == 3)
                {
                    Console.Write("How Update Phone Number: ");
                    var oldPhoneNumber = Console.ReadLine();
                    Console.Write("New Phone Number: ");
                    var newPhoneNumber = Console.ReadLine();
                    var boolResult = UpdatePhoneNumber(oldPhoneNumber, newPhoneNumber);
                    if (boolResult is true)
                    {
                        Console.WriteLine("Updated");
                    }
                    else
                    {
                        Console.WriteLine("Not Update");
                    }
                }
                else if (option == 4)
                {
                    Console.Write("Enter new serie: ");
                    var phoneNumber = Console.ReadLine();
                    var boolResult = DelatePhoneNumber(phoneNumber);
                    if (boolResult is true)
                    {
                        Console.WriteLine("Delated");
                    }
                    else
                    {
                        Console.WriteLine("Not delate");
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static int AddPhoneNumber(string phoneNumber)
        {
            var exists = PhoneNumbers.Contains(phoneNumber);
            var isCheck = CheckPhoneNumber(phoneNumber);
            if (exists is true || isCheck is false)
            {
                return -1;
            }
            PhoneNumbers.Add(phoneNumber);

            return PhoneNumbers.Count - 1;
        }
        public static List<string> ReadPhoneNumber()
        {
            return PhoneNumbers;
        }
        public static bool UpdatePhoneNumber(string oldPhoneNumber, string newPhoneNumber)
        {
            var index = PhoneNumbers.IndexOf(oldPhoneNumber);
            var isCheck = CheckPhoneNumber(newPhoneNumber);
            var boolResult = true;
            if (index < 0 || isCheck is false)
            {
                return boolResult;
            }

            PhoneNumbers[index] = newPhoneNumber;
            boolResult = true;
            return boolResult;
        }
        public static bool DelatePhoneNumber(string phoneNumber)
        {
            var exists = PhoneNumbers.Contains(phoneNumber);
            PhoneNumbers.Remove(phoneNumber);
            return exists;
        }
        public static bool CheckPhoneNumber(string phoneNumber)
        {
            var firstCheck = phoneNumber[0] == '9';
            var secondCheck = phoneNumber[1] == '9' || phoneNumber[1] == '7' || phoneNumber[1] == '8' || phoneNumber[1] == '3' || phoneNumber[1] == '1' || phoneNumber[1] == '4' || phoneNumber[1] == '0';
            var thirdCheck = phoneNumber.Length == 9;
            var fourthCheck = true;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (Char.IsDigit(phoneNumber[i]) is false)
                {
                    firstCheck = false;
                    break;
                }
            }
            return firstCheck && secondCheck && thirdCheck && fourthCheck;
        }
    }
}
