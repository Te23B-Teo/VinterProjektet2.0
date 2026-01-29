public class Stranger : Caracter
{
    public int ConversationCount = 0;  // Räknar hur många gånger du pratat med denna person

    public Stranger(string name, string pname, int age) : base(name, pname, age)  // gör så att man kan använda variablerna utanför denna metod
    {
    }

    public void TalkWithStranger()
    {
        ConversationCount++;
        Console.WriteLine($"\n{Name}: Hej {PName} Jag heter {Name} och är {Age} år gammal.");
        
        if (ConversationCount == 1)
            Console.WriteLine($"{Name}: vilke är din favorit siffra?");
        else if (ConversationCount == 2)
            Console.WriteLine($"{Name}: Du är en trevlig typ du!");
        else if (ConversationCount >= 3)
            Console.WriteLine($"{Name}: kan du räkna till 100 jag kan 1,2,3...");
    }

    public bool BecomesFriend()
    {
        return ConversationCount >= 3;  // När man pratat med en främling 3 gånger så blir dom din vänn sen
    }
}