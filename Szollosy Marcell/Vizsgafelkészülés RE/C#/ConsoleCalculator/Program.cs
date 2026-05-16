using ConsoleCalculator;

bool run = true;

while (run) {                                                               //fut amíg run értéke igaz
    Console.WriteLine("Write two number and a calculation method (+-/*)");  //kiír egy sort
    var line = Console.ReadLine();                                          // beolvas egy sort

    char[] calcTypes = ['+', '-', '*', '/'];                                // karakter tömb

    Calculator calculator = new Calculator();                               // példányosítja a Calculator osztályt
    if (calcTypes.Any(line.Contains))                                       // végig megy a calcTypes tömbön és megnézi hogy bármely karakter benne van-e a line stringbe
    {
        int calcIndex = line.IndexOfAny(calcTypes);                         // kikeresi melyik indexen található valamelyik kalkuláció típus

        string num1AsString = line.Substring(0, calcIndex);                 // a line stringnek a 0-adik indextől kezdődő calcIndex hosszú rész stringjét veszi
        char calc = line[calcIndex];                                        // lekéri a line stringből a calcIndex indexen lévő karaktert
        string num2AsString = line.Substring(calcIndex + 1);                // a line string (calcIndex + 1) - től kezdőd rész sztringet lekéri

        int num1 = int.Parse(num1AsString);                                 // konvertál inté
        int num2 = int.Parse(num2AsString);
        int result = 0;

        if (calc == '+')                                                    // ha a bekért stringben + kalkuláció van
        {
            result = calculator.Add(num1, num2);                            // meghívja a két számra az Add függvényt
        }
        else if (calc == '-')
        {
            result = calculator.Subtract(num1, num2);
        }
        else if (calc == '*')
        {
            result = calculator.Multiply(num1, num2);
        }
        else if (calc == '/')
        {
            result = calculator.Divide(num1, num2);
        }

        Console.WriteLine("The result is: " + result + "Num of calcs: " + calculator.NumOfCalcs() + "Num of calcs static: " + Calculator.NumOfCalcsStatic());
        //kiírja az eredményt, a NumOfCalcStatic az osztályra hívható meg mert static
    }
    else if (line.Equals("stop"))                                           // ha stop-ot írunk be akkor belép
    {
        run = false;                                                        // átállítja a run változót false-ra
    }
    else
    {
        Console.WriteLine("This type of calculation cannot be solved.");    // kiírja hogy hibás a bevitt string
    }
}
