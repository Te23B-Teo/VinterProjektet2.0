public class Friend : Caracter
{
    public Friend(string name, string pname, int age) : base(name, pname, age) // gör så att man kan använda variablerna utanför denna metod
    {
    }

    public void TalkWithFriend()  // metod för att vänner ska kunna introducera sig själva
    {
        Console.WriteLine($"{Name}: Hej {PName}! ");
        Console.WriteLine($"{Name}: Vi är bra vänner {PName} XD");
    }

    public int GainPopularity()
    {
        int popularityGain = 2;  // när du pratat med en kompis så får du popularitet poäng
        Console.Clear();
        Console.WriteLine($"+{popularityGain} populäritets poäng för att prata med vän!");
        return popularityGain;
    }
}