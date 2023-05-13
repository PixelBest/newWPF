using newWPF.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newWPF.Model
{
    abstract class Creator     //Абстрактный класс создания
    {
        public abstract AnimalsTable Create(string name, string age, string gender);
    }

    class CreateMammals : Creator   //Создаёт млекопитающее
    {
        public override AnimalsTable Create(string name, string age, string gender)
        {
            return new Mammals(name, age, gender);
        }
    }

    class CreateBirds : Creator    //Создаёт птиц
    {
        public override AnimalsTable Create(string name, string age, string gender)
        {
            return new Birds(name, age, gender);
        }
    }

    class CreateAmphibians : Creator    //Создаёт земноводных
    {
        public override AnimalsTable Create(string name, string age, string gender)
        {
            return new Amphibians(name, age, gender);
        }
    }

    class CreateUnknown : Creator    //Создаёт неизвестных животных
    {
        public override AnimalsTable Create(string name, string age, string gender)
        {
            return new UnknownAnimals(name, age, gender);
        }
    }
}
