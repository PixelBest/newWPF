using newWPF.DataBase;
using newWPF.Presenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace newWPF.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAnimalsView
    {
        private AnimalsEntities animalsEntities = new AnimalsEntities();
        private ObservableCollection<AnimalsTable> listAnimals;
        ObservableCollection<AnimalsTable> IAnimalsView.ListAnimals   //создание свойства для коллекции животных
        {
            get => listAnimals;
            set => listAnimals = value;
        }

        AnimalsEntities IAnimalsView.AnimEnt    //создание свойства для Entities
        {
            get => animalsEntities; 
        }
        public MainWindow()
        {
            InitializeComponent();
            BindingButtons();
            LoadData();
        }

        public string IdText    //создание свойства для textBox поля Id
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public string KindOfAnimalsText     //создание свойства для textBox поля KindOfAnimals
        {
            get => t1.Text;
            set => t1.Text = value; 
        }
        public string NameText    //создание свойства для textBox поля Name
        {
            get => t2.Text;
            set => t2.Text = value; 
        }
        public string AgeText    //создание свойства для textBox поля Age
        { 
            get => t3.Text; 
            set => t3.Text = value;
        }
        public string GenderText    //создание свойства для textBox поля Gender
        {
            get => t4.Text; 
            set => t4.Text = value; 
        }

        private DeleteAnimation deleteAnim;
        private AddAnimation addAnim;
        private UpdateAnimation updateAnim;
        private ClearAnimation clearAnim;
        private CreateAnimation createAnim;

        event AddAnimation IAnimalsView.AddAnimaEvent   //создание свойства для делегата addAnim
        {
            add => addAnim += value;
            remove => addAnim -= value;
        }

        event DeleteAnimation IAnimalsView.DeleteAnimEvent  //создание свойства для делегата deleteAnim
        {
            add => deleteAnim += value;
            remove => deleteAnim -= value;
        }

        event UpdateAnimation IAnimalsView.UpdateAnimEvent   //создание свойства для делегата updateAnim
        {
            add => updateAnim += value;
            remove => updateAnim -= value;
        }

        event ClearAnimation IAnimalsView.ClearAnimEvent  //создание свойства для делегата clearAnim
        {
            add => clearAnim += value;
            remove => clearAnim -= value;
        }

        event CreateAnimation IAnimalsView.CreateAnimEvent  //создание свойства для делегата createAnim
        {
            add => createAnim += value;
            remove => createAnim -= value;
        }

        private void BindingButtons()   //привязка кнопок к методам
        {
            new AnimalsPresenter(this);
            btnAdd.Click += delegate { addAnim?.Invoke(); };
            btnUpdate.Click += delegate { updateAnim?.Invoke(); };
            btnDel.Click += delegate { deleteAnim?.Invoke(); };
            btnClear.Click += delegate { clearAnim?.Invoke(); };
            btnCreate.Click += delegate { createAnim?.Invoke(); };
        }

        public void ClearTextBox()  //метод очищающий TextBox-ы
        {
            t1.Text = ""; t2.Text = ""; t3.Text = ""; t4.Text = ""; textBox1.Text = "";
        }

        public void LoadData()  //метод загружающий данные из SQL Server в кроллекцию животных
        {
            if(listAnimals != null)
                listAnimals.Clear();
            listAnimals = new ObservableCollection<AnimalsTable>(animalsEntities.AnimalsTable);
            lv1.ItemsSource = listAnimals;
        }
    }
}
