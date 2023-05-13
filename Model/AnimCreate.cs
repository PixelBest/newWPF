using newWPF.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newWPF.Model
{
    public class CreateAnim
    {
        public static ObservableCollection<AnimalsTable> anim = new ObservableCollection<AnimalsTable>();
        public static void Create()     //метод создания 6 животных
        {
            Creator creator = new CreateMammals();
            AnimalsTable anim1 = creator.Create("Тигр", "10", "М");
            anim1.KindOfAnimal = "Млекопитающее";
            anim.Add(anim1);

            creator = new CreateBirds();
            AnimalsTable anim2 = creator.Create("Голубь", "3", "Ж");
            anim2.KindOfAnimal = "Птица";
            anim.Add(anim2);

            creator = new CreateAmphibians();
            AnimalsTable anim3 = creator.Create("Лягушка", "1", "М");
            anim3.KindOfAnimal = "Земноводное";
            anim.Add(anim3);

            creator = new CreateMammals();
            AnimalsTable anim4 = creator.Create("Панда", "6", "Ж");
            anim4.KindOfAnimal = "Млекопитающее";
            anim.Add(anim4);

            creator = new CreateBirds();
            AnimalsTable anim5 = creator.Create("Колибри", "8", "М");
            anim5.KindOfAnimal = "Птица";
            anim.Add(anim5);

            creator = new CreateAmphibians();
            AnimalsTable anim6 = creator.Create("Жаба", "2", "Ж");
            anim6.KindOfAnimal = "Земноводное";
            anim.Add(anim6);
        }
    }
}
