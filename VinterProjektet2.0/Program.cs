List<Stranger> strangers = new List<Stranger>();
List<Friend> friends = new List<Friend>();


string PName = "";
int playerPopularity = 0;
bool SpelIgång = true;


Console.WriteLine("Välkomen till pratsim");
Console.WriteLine("");
Console.WriteLine("Vad vill du heta? ");
PName = Console.ReadLine();
Console.Clear();
Console.Write("Hur gammal är du? ");
int playerAge = int.Parse(Console.ReadLine());
Console.Clear();
if(playerAge > 20 || playerAge < 15){
    Console.WriteLine("Du måste vara mellan 15 och 20 år gammal!");
    Thread.Sleep(1000);
    return;
}

Console.WriteLine($"Hej {PName}! Du är {playerAge} år gammal.");

string[] strangerNames = { "Elis", "Anton", "Nils", "Anna", "Oscar", "Lisa", "Erik", "Julia", "Martin" };
int[] strangerAges = { 15, 18, 16, 19, 17, 20, 18, 15, 18 };


// Skapar lisan för stranger metoden för att lagras
for (int i = 0; i < strangerNames.Length; i++)
{
    strangers.Add(new Stranger(strangerNames[i], PName, strangerAges[i]));
}

while (SpelIgång)
{
    Console.WriteLine($@"
    Popularitet: {playerPopularity}/20

    Vad vill du göra?

    1. Lista på personer
    2. Prata med klasskamrater
    3. Avsluta spelet

    Välj mellan 1-3
    ");
     string val = Console.ReadLine();
     Console.Clear();

    if (val == "1")
    {
        ShowPersonList();
    }
    else if (val == "2")
    {
        TalkWithSomeone();
    }
    else if (val == "3")
    {
        Console.WriteLine("Bra spelat!");
        SpelIgång = false;
    }
    else
    {
        Console.WriteLine("Går inte att skriva det!");
    }

    if (playerPopularity >= 20) // när spelaren har 20 i popularitet så har den blivit tillräkligt känns så vinner man
    {
        Console.Clear();
        Console.WriteLine("GRATTIS du vannnnnn!!!!!!");
        Console.WriteLine("");
        Console.WriteLine($"Du fick 20 poäng! Du är nu den mest populära personen WOHOO,Grattis {PName}!");
        Console.WriteLine($"du fick så här många vänner ({friends.Count})");
        Console.WriteLine("");
        Console.WriteLine("tryck på enter om du vill avsluta!");
        SpelIgång = false;
    }
}

void ShowPersonList()
{
    Console.WriteLine("Kompisar");
    for (int i = 0; i < friends.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {friends[i].Name} ({friends[i].Age} år) - kompisar");
    }

    Console.WriteLine("Strangers");
    for (int i = 0; i < strangers.Count; i++)
    {
        Console.WriteLine($"{friends.Count + i + 1}. {strangers[i].Name} ({strangers[i].Age} år)  prata: {strangers[i].ConversationCount}/3");
    }
}


void TalkWithSomeone()
{
    Console.WriteLine("Vem ska du prata med");
    ShowPersonList();
    Console.WriteLine("välj vem du vill prata med skriv siffror");
    
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.Clear();
        choice--; 

        if (choice >= 0 && choice < friends.Count)
        {
          
            Friend friend = friends[choice];
            friend.TalkWithFriend();
            playerPopularity += friend.GainPopularity();
        }
        else if (choice >= friends.Count && choice < friends.Count + strangers.Count)
        {
            
            int strangerIndex = choice - friends.Count;
            Stranger stranger = strangers[strangerIndex];
            
            stranger.TalkWithStranger();
            playerPopularity += 1;

            
            if (stranger.BecomesFriend())
            {
                Console.WriteLine($"Du har blivit vänn med {stranger.Name}");
                
                Friend newFriend = new Friend(stranger.Name, PName, stranger.Age);
                friends.Add(newFriend);
                strangers.RemoveAt(strangerIndex);
            }
        }
        else
        {
            Console.WriteLine("går inte att välja det!");
        }
    }
    else
    {
        Console.WriteLine("går inte att välja det!");
    }
}
Console.ReadLine();