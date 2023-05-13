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
        public AnimalsEntities animalsEntities = new AnimalsEntities();
        public ObservableCollection<AnimalsTable> OCAnimals;
        public MainWindow()
        {
            InitializeComponent();
            BindingButtons();
            LoadData();
        }

        public string IdText
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public string KindOfAnimalsText 
        {
            get => t1.Text;
            set => t1.Text = value; 
        }
        public string NameText
        {
            get => t2.Text;
            set => t2.Text = value; 
        }
        public string AgeText
        { 
            get => t3.Text; 
            set => t3.Text = value;
        }
        public string GenderText
        {
            get => t4.Text; 
            set => t4.Text = value; 
        }

        private DeleteAnimation deleteAnim;
        private AddAnimation addAnim;
        private UpdateAnimation updateAnim;
        private ClearAnimation clearAnim;
        private CreateAnimation createAnim;

        event AddAnimation IAnimalsView.AddAnimaEvent
        {
            add => addAnim += value;
            remove => addAnim -= value;
        }

        event DeleteAnimation IAnimalsView.DeleteAnimEvent
        {
            add => deleteAnim += value;
            remove => deleteAnim -= value;
        }

        event UpdateAnimation IAnimalsView.UpdateAnimEvent
        {
            add => updateAnim += value;
            remove => updateAnim -= value;
        }

        event ClearAnimation IAnimalsView.ClearAnimEvent
        {
            add => clearAnim += value;
            remove => clearAnim -= value;
        }

        event CreateAnimation IAnimalsView.CreateAnimEvent
        {
            add => createAnim += value;
            remove => createAnim -= value;
        }

        private void BindingButtons()
        {
            new AnimalsPresenter(this);
            btnAdd.Click += delegate { addAnim?.Invoke(); };
            btnUpdate.Click += delegate { updateAnim?.Invoke(); };
            btnDel.Click += delegate { deleteAnim?.Invoke(); };
            btnClear.Click += delegate { clearAnim?.Invoke(); };
            btnCreate.Click += delegate { createAnim?.Invoke(); };
        }

        public void ClearTextBox()
        {
            t1.Text = ""; t2.Text = ""; t3.Text = ""; t4.Text = ""; textBox1.Text = "";
        }

        public void LoadData()
        {
            if(OCAnimals != null)
                OCAnimals.Clear();
            OCAnimals = new ObservableCollection<AnimalsTable>(animalsEntities.AnimalsTable);
            lv1.ItemsSource = OCAnimals;
        }
    }
}
