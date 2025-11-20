using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrainFuckTranslator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
    }
    public int currentpointervalue = 0;
    public string outputstring = "";
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (Inputbox.Text != "") {
        foreach(char letter in Inputbox.Text)
            {
                if ((int)letter < 128 )
                {
               
                    PointerMove((int)letter);
                   
                }


            }

            File.WriteAllText("Output.txt", outputstring);


        }
    }


    public void IncrepemtPointer(int target)
    {
        
            if (target - currentpointervalue > 9)
            {

                outputstring += ">+++++[<";
                bool doloop = true;
                while (doloop)
                {
                    if (currentpointervalue + 5 == target)
                    {

                        currentpointervalue += 5;
                        outputstring += "+>-]<";
                        doloop = false;

                    }
                    else if (currentpointervalue + 5 > target)
                    {

                        doloop = false;

                        outputstring += ">-]<";
                    }
                    else
                    {

                        currentpointervalue += 5;
                        outputstring += "+";
                    }


                }


            }
      

            while (currentpointervalue < target)
            {
                outputstring += "+";
                currentpointervalue++;
            }


      




    }

    public void DecrementPointer(int target)
    {

       
        if (currentpointervalue -   target > 9)
        {

            outputstring += ">+++++[<";
            bool doloop = true;
            while (doloop)
            {
                if (currentpointervalue - 5 == target)
                {

                    currentpointervalue -= 5;
                    outputstring += "->-]<";
                    doloop = false;

                }
                else if (currentpointervalue - 5 < target)
                {

                    doloop = false;

                    outputstring += ">-]<";
                }
                else
                {

                    currentpointervalue -= 5;
                    outputstring += "-";
                }


            }


        }
      
            while (currentpointervalue > target)
            {
                outputstring += "-";
                currentpointervalue--;
            }


      

    }
    public void PointerMove(int target)
    {

     
        if (currentpointervalue == target)
        {
            outputstring += ".";
        } else if (currentpointervalue < target) {
            IncrepemtPointer(target);
            outputstring += ".";
        } else
        {
            DecrementPointer(target);
            outputstring += ".";
        }


        outputstring += "\r\n";



    }





}