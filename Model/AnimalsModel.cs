using Microsoft.Win32;
using newWPF.DataBase;
using newWPF.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace newWPF.Model
{
    public class AnimalsModel : IAnimalsModel
    {
        void IAnimalsModel.Add(string kindOfAnimal, string name, string age, string gender, IAnimalsView view)      //реализация метода добавления
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

        void IAnimalsModel.Clear(IAnimalsView view)     //реализация метода очистки ListView
        {
            for (int i = view.ListAnimals.Count - 1; i >= 0; i--)
            {
                view.AnimEnt.AnimalsTable.Remove(view.ListAnimals[i]);
                view.AnimEnt.SaveChanges();
                view.ListAnimals.Remove(view.ListAnimals[i]);
            }
        }

        void IAnimalsModel.Create(IAnimalsView view)        //реализация метода создания 6 животных
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
        void IAnimalsModel.Delete(string id, IAnimalsView view)     //реализация метода удаления животных
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

        void IAnimalsModel.Update(string id, string kindOfAnimal, string name, string age, string gender, IAnimalsView view)        //реализация метода обновления животных в бд
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
        void IAnimalsModel.Save(IAnimalsView view)      //реализация метода сохранения данных
        {
            int count = 1;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Animals";
            sfd.Filter = "Text file (*.txt)|*.txt| Xml file (*.xml)|*.xml";
            if (sfd.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    foreach (AnimalsTable animals in view.ListAnimals)
                    {
                        sw.WriteLine($"{count}) Вид: {animals.KindOfAnimal}, название: {animals.Name}, возраст:{animals.Age}, пол:{animals.Gender}");
                        count++;
                    }
                MessageBox.Show("Сохранение прошло успешно");
            }
        }
    }
}
