using System;

namespace SF_Module5_FinalProject
{
	class Program
	{
		static void Main(string[] args)
		{
			var User = UserBlock();

			Console.Clear();

			UserShow(User);

			Console.ReadKey();
		}

		static (string Name, string LastName, int Age, string[] Pets, string[] FavColors) UserBlock()
		{
			(string Name, string LastName, int Age, string[] Pets, string[] FavColors) User;

			Console.WriteLine("Введите ваше имя: ");
			User.Name = Console.ReadLine();
            Console.WriteLine();

			Console.WriteLine("Введите вашу фамилию: ");
			User.LastName = Console.ReadLine();
            Console.WriteLine();

			string ageStr;
			int ageInt;

			do
			{
				Console.WriteLine("Введите ваш возраст: ");
				ageStr = Console.ReadLine();
			} while (NumValidation(ageStr, out ageInt));

			User.Age = ageInt;

            Console.WriteLine();

			Console.WriteLine("Есть ли у вас домашние животные? (Да | Нет)");

			string havePets = Console.ReadLine();

			string petsStr;
			int petsNum = 0;
			string[] petsTemp;
			User.Pets = null;

			if (havePets == "Да")
			{
				do
				{
                    Console.WriteLine();
					Console.WriteLine("Сколько у вас домашних животных?");
					petsStr = Console.ReadLine();
				} while (NumValidation(petsStr, out petsNum));

				Console.WriteLine();
				Console.WriteLine("Как их зовут?");	
			}

			petsNicks(petsNum, out petsTemp);

			User.Pets = petsTemp;

			string colorsStr;
			int colorsQuantity = 0;
			string[] colorsTemp;

            Console.WriteLine();

			do
			{
				Console.WriteLine("Введите количество ваших любимых цветов");
				colorsStr = Console.ReadLine();
			} while (NumValidation(colorsStr, out colorsQuantity));

            Console.WriteLine();

            Console.WriteLine("Назовите ваши любимые цвета");
			colorsFavs(colorsQuantity, out colorsTemp);

			User.FavColors = colorsTemp;

			return User;
		}

		static bool NumValidation(string numStr, out int numOut)
		{
			if (int.TryParse(numStr, out int numInt))
			{
				if (numInt > 0)
				{
					numOut = numInt;
					return false;
				}
			}

			numOut = 0;

			return true;
		}

		static string[] petsNicks(int quantity, out string[] pets)
		{
			string[] nicks = new string[quantity];

			for (int i = 0; i < nicks.Length; i++)
			{
				nicks[i] = Console.ReadLine();
			}

			pets = nicks;

			return pets;
		}

		static string[] colorsFavs(int quantity, out string[] colors)
		{
			string[] favs = new string[quantity];

			for (int i = 0; i < favs.Length; i++)
			{
				favs[i] = Console.ReadLine();
			}

			colors = favs;

			return colors;
		}

		public static void UserShow((string Name, string LastName, int Age, string[] Pets, string[] FavColors) User)
        {
            Console.WriteLine("***");
            Console.WriteLine();
            Console.WriteLine("Имя: {0}", User.Name);
            Console.WriteLine("Фамилия: {0}", User.LastName);
            Console.WriteLine("Возраст: {0}", User.Age);
            Console.WriteLine();

			int petsNums = User.Pets.Length;

			if (User.Pets != null)
            {
				Console.WriteLine("[Домашних животных - {0}]", petsNums);
                Console.WriteLine();

                foreach (var nicknames in User.Pets)
                {
                    Console.WriteLine("- " + nicknames);
                }

                Console.WriteLine();
			}

			int colorsNums = User.FavColors.Length;

			Console.WriteLine("[Любимых цветов - {0}]", colorsNums);
            Console.WriteLine();

			foreach (var favourites in User.FavColors)
			{
				Console.WriteLine("- " + favourites);
			}

            Console.WriteLine();
			Console.WriteLine("***");
		}
	}
}




