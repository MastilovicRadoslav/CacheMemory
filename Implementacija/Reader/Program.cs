using CacheMemory.Reader;
using CacheMemory.Structures.Implementations;

Historical historical = new();

Reader reader = new Reader(historical);

//reader.SearchByMonth(1);

var option = string.Empty;
while (!option.Equals("0"))
{
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine("Unesite opciju po kojoj želite da se ispišu podaci :");
    Console.WriteLine("\t1. Ispis podataka po mesecu!");
    Console.WriteLine("\t2. Ispis podataka po IDu korisnika!");
    Console.WriteLine("\t3. Ispis podataka po nazivu grada!");
    Console.WriteLine("\t0. Kraj aplikacije!");
    option = Console.ReadLine();
    Console.WriteLine("----------------------------------------------------------------");

    switch (option)
    { 
        case "1": 
        {
            Console.WriteLine("Unesite broj meseca koji želite (1-12) :");
            var input = Console.ReadLine();
            var valid = int.TryParse(input, out var monthId);

            if (!valid)
            {
                Console.WriteLine("Greška! Morate uneti broj između 1 i 12!");
                break;
            }

                reader.SearchByMonth(monthId).ForEach(r =>
            {
                Console.WriteLine(r);
            });

            break;
        }
        case "2":
        {
                Console.WriteLine("Unesite ID korisnika koji želite :");
                var input = Console.ReadLine();
                var valid = int.TryParse(input, out var userId);
                if (!valid) 
                {
                    Console.WriteLine("Greška! Morate uneti validan ID korisnika!");
                    break;
                }


                reader.SearchByUser(userId).ForEach(r =>
                {
                    Console.WriteLine(r);
                });
                break;
        }
        case "3":
        {
            Console.WriteLine("Unesite naziv grada koji želite :");
            var input = Console.ReadLine();

            reader.SearchCityName(input).ForEach(r =>
            {
                Console.WriteLine(r);
            });

            break;
        }
        default:
        {
            Console.WriteLine("Pogrešna opcija! Morate uneti 1, 2 ili 3 kao opciju da bi dobili ispis!");
            break;
        }
    }
}
