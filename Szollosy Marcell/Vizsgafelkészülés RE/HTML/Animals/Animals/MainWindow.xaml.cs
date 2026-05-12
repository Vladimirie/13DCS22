using System.Windows;

namespace Animals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

            List<Animal> animals = new List<Animal>();
            public MainWindow()
            {
            InitializeComponent();
            //cbType.ItemsSource = Enum.GetValues(typeof(AnimalTypes));
            List<string> animalType = new List<string> { "Cat", "Dog" };
            cbType.ItemsSource = animalType;
            
            }

        private void AddAnimal(object sender, RoutedEventArgs e)
        {
            string selectedAnimalType = cbType.SelectedItem.ToString();
            if (selectedAnimalType == "Cat")
            {
                Cat newCat = new Cat(tbName.Text, tbeOwner.Text, tbLivesAt.Text, Convert.ToInt32(tbAge.Text));
            }
            else if (selectedAnimalType == "Dog")
            {
                Dog newDog = new Dog(tbName.Text, tbeOwner.Text, tbLivesAt.Text, Convert.ToInt32(tbAge.Text));
                animals.Add(newDog);
            }
            dgAnimals.ItemsSource = animals;
        }
        private void Refresh()
        {
            List<string> animalStatuses = new List<string>;
            animals.ForEach(animal => { animalStatuses.Add(animal.Status()); });
            dgAnimals.ItemsSource = animalStatuses;
        }
        /*
private void NumberValidation(object sender, TextCompositionEventArgs e)
{
   Regex regex = new Regex("[^0-9]+");
   e.Handled = regex.IsMatch(e.Text);
}
*/
    }
}