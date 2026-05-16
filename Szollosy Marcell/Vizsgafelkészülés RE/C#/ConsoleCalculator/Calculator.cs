namespace ConsoleCalculator
{
    public class Calculator
    {
        static int numOfCalculationsStatic = 0;                     // olyan változó, ami az osztályhoz tartozik (nincs minden példánynak sajátja), minden példány ugynazt az egy változót éri el és modifikálja
        readonly int numOfCalsReadonly = 0;                         // nem adható új érték neki
        int numOfCalculations = 0;
        public int Add(int num1, int num2)
        {
            numOfCalculations++;                                    // eggyel megnöveli a változót
            numOfCalculationsStatic++;
            //numOfCalsReadonly++;                                  - hibát dobna mert nem változtatható meg
            return num1 + num2;
        }

        public int Subtract(int num1, int num2)
        {
            numOfCalculations++;
            numOfCalculationsStatic++;
            return num1 - num2;
        }
        public int Multiply(int num1, int num2)
        {
            numOfCalculations++;
            numOfCalculationsStatic++;
            return num1 * num2;
        }
        public int Divide(int num1, int num2)
        {
            numOfCalculations++;
            numOfCalculationsStatic++;
            return num1/num2;
        }

        public int NumOfCalcs()
        {
            return numOfCalculations;
        }

        public static int NumOfCalcsStatic()                        // az osztályhoz tartozik a függvény, nem hívható meg példányra (csak static változókat ér el)
        {
            //numOfCalculations++;                                  - ezért ez a sor hibát dobna
            return numOfCalculationsStatic;                         // static változó így eléri
        }
    }
}
