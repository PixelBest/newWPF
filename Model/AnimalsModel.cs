using newWPF.DataBase;
using newWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newWPF.Model
{
    public class AnimalsModel : IAnimalsModel
    {
        void IAnimalsModel.Add(string kindOfAnimal, string name, string age, string gender, IAnimalsView view)
        {
            AnimalsTable animalsTable = new AnimalsTable();
            int nextId = 1;
            foreach (var anim in view.ListAnimals)
            {
                if (nextId <= int.Parse(anim.Id))
                    nextId = int.Parse(anim.Id) + 1;
            }
            animalsTable.Id = nextId.ToString();
            animalsTable.KindOfAnimal = kindOfAnimal;
            animalsTable.Name = name;
            animalsTable.Age = age;
            animalsTable.Gender = gender;
            view.ListAnimals.Add(animalsTable);
            view.AnimEnt.AnimalsTable.Add(animalsTable);
            view.AnimEnt.SaveChanges();
            view.ClearTextBox();
        }

        void IAnimalsModel.Clear(IAnimalsView view)
        {
            for (int i = view.ListAnimals.Count - 1; i >= 0; i--)
            {
                view.AnimEnt.AnimalsTable.Remove(view.ListAnimals[i]);
                view.AnimEnt.SaveChanges();
                view.ListAnimals.Remove(view.ListAnimals[i]);
            }
        }

        void IAnimalsModel.Create(IAnimalsView view)
        {
            CreateAnim.anim.Clear();
            CreateAnim.Create();
            foreach (var anim in CreateAnim.anim)
            {
                AnimalsTable animalsTable = new AnimalsTable();
                int nextId = 1;
                foreach (var anim1 in view.ListAnimals)
                {
                    if (nextId <= int.Parse(anim1.Id))
                        nextId = int.Parse(anim1.Id) + 1;
                }
                animalsTable.Id = nextId.ToString();
                animalsTable.KindOfAnimal = anim.KindOfAnimal;
                animalsTable.Name = anim.Name;
                animalsTable.Age = anim.Age;
                animalsTable.Gender = anim.Gender;
                view.ListAnimals.Add(animalsTable);
                view.AnimEnt.AnimalsTable.Add(animalsTable);
                view.AnimEnt.SaveChanges();
            }
        }

        void IAnimalsModel.Delete(string id, IAnimalsView view)
        {
            for (int i = 0; i < view.ListAnimals.Count; i++)
            {
                if (int.Parse(id) == int.Parse(view.ListAnimals[i].Id))
                {
                    view.AnimEnt.AnimalsTable.Remove(view.ListAnimals[i]);
                    view.AnimEnt.SaveChanges();
                    view.ClearTextBox();
                    view.LoadData();
                    break;
                }
            }
        }

        void IAnimalsModel.Update(string id, string kindOfAnimal, string name, string age, string gender, IAnimalsView view)
        {
            for (int i = 0; i < view.ListAnimals.Count; i++)
            {
                if (int.Parse(id) == int.Parse(view.ListAnimals[i].Id))
                {
                    view.ListAnimals[i].KindOfAnimal = kindOfAnimal;
                    view.ListAnimals[i].Name = name;
                    view.ListAnimals[i].Age = age;
                    view.ListAnimals[i].Gender = gender;
                    view.AnimEnt.SaveChanges();
                    view.LoadData();
                    view.ClearTextBox();
                    break;
                }
            }
        }
    }
}
