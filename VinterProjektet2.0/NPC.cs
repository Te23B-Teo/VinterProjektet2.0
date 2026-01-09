public class Caracter
{
public int Popular;
public string Name;
public string PName;
public int Age;
public bool HowPopular;



public void Talk()
    {
    Console.WriteLine($"{Name}: Hej {PName}! Jag heter {Name} och är {Age} år gammal.");
    }
}