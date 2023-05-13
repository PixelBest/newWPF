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
        public event EventHandler DeleteAnim;
        public event EventHandler AddAnim;
        public event EventHandler UpdateAnim;
        public event EventHandler ClearAnim;
        public event EventHandler CreateAnim;

        public MainWindow()
        {
            InitializeComponent();
            BindingButtons();
            LoadData();
        }

        private void BindingButtons()
        {
            new AnimalsPresenter(this);
            btnAdd.Click += delegate { AddAnim?.Invoke(this, EventArgs.Empty); };
            btnUpdate.Click += delegate { UpdateAnim?.Invoke(this, EventArgs.Empty); };
            btnDel.Click += delegate { DeleteAnim?.Invoke(this, EventArgs.Empty); };
            btnClear.Click += delegate { ClearAnim?.Invoke(this, EventArgs.Empty); };
            btnCreate.Click += delegate { CreateAnim?.Invoke(this, EventArgs.Empty); };
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
