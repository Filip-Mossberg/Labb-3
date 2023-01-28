namespace Labb_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgramStart();
        }
        public static void ProgramStart()
        {
            Menu menu = new Menu();
            menu.MenuList();
        }
    }
}