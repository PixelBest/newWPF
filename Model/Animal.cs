using newWPF.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newWPF.Model
{
    public class Mammals : AnimalsTable //Млекопитающие
    {
        private string kindOfAnimal;
        public string KindOfAnimal
        {
            get => kindOfAnimal;
            set => kindOfAnimal = value;
        }
        public Mammals(string name, string age, string gender) : base(name, age, gender) { KindOfAnimal = "Млекопитающее"; }
        public Mammals() : base("", "", "") { }
    }

    public class Birds : AnimalsTable //Птицы
    {
        private string kindOfAnimal;
        public string KindOfAnimal
        {
            get => kindOfAnimal;
            set => kindOfAnimal = value;
        }
        public Birds(string name, string age, string gender) : base(name, age, gender) { KindOfAnimal = "Птица"; }
        public Birds() : base("", "", "") { }
    }

    public class Amphibians : AnimalsTable  //Земноводные
    {
        private string kindOfAnimal;
        public string KindOfAnimal
        {
            get => kindOfAnimal;
            set => kindOfAnimal = value;
        }
        public Amphibians(string name, string age, string gender) : base(name, age, gender) { KindOfAnimal = "Земноводное"; }
        public Amphibians() : base("", "", "") { }
    }

    public class UnknownAnimals : AnimalsTable  //Неизвестные животные
    {
        private string kindOfAnimal;
        public string KindOfAnimal
        {
            get => kindOfAnimal;
            set => kindOfAnimal = value;
        }
        public UnknownAnimals(string name, string age, string gender) : base(name, age, gender) { KindOfAnimal = "Неизвестное"; }
        public UnknownAnimals() : base("", "", "") { }
    }
}
