/*
Változók
*/
int kor = 20;
string nev = "Péter";
double atlag = 4.5;
bool aktív = true;
/*
Elágazások
*/
if (kor >= 18)
{
    Console.WriteLine("Felnőtt");
}
else
{
    Console.WriteLine("Kiskorú");
}
/*
Ciklusok
*/
for(int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
while (feltetel)
{
}
/*
Lista
*/
List<string> nevek = new List<string>();
nevek.Add("Anna");
/*
Metódusok
*/
static int Összeg(int a, int b)
{
    return a + b;
}