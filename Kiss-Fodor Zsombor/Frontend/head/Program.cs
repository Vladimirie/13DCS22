namespace head
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int screemW = Console.BufferWidth;
            int screemH = Console.BufferHeight;
            Bald(screemW /2 - 10 ,screemH / 2 - 40, 20);
            Bald(screemW / 2 - 10, screemH / 2 - 30, 20);
            Side(screemW / 2 - 10, screemH / 2 - 39, (screemH / 2 - 39) + 8);
            Side(screemW / 2 + 10, screemH / 2 - 39, (screemH / 2 - 39) + 8);
            Console.SetCursorPosition(screemW / 2 - 20, screemH / 2 - 40);
        }

        static void Bald(int x, int y, int lenght)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < lenght; i++) 
            {
                Console.Write("-");
            }
        }

        static void Side(int x, int y, int height)
        {   
            for (int yremaint = y; yremaint < height; yremaint++)
            {
                Console.SetCursorPosition(x, yremaint);
                Console.Write("|");
            }
        }
    }
}
