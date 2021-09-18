 namespace Playground.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(args[0]);
            int result = HalsteadStats.HalsteadStatExample.AlterValue(value);

            System.Console.WriteLine(result);
            System.Console.ReadLine();
        }
    }
}
