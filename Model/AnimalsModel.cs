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
        public void Add(string kindOfAnimal, string name, string age, string gender, MainWindow mw)
        {
            AnimalsTable animalsTable = new AnimalsTable();
            int nextId = 1;
            foreach (var anim in mw.OCAnimals)
            {
                if (nextId <= int.Parse(anim.Id))
                    nextId = int.Parse(anim.Id) + 1;
            }
            animalsTable.Id = nextId.ToString();
            animalsTable.KindOfAnimal = kindOfAnimal;
            animalsTable.Name = name;
            animalsTable.Age = age;
            animalsTable.Gender = gender;
            mw.OCAnimals.Add(animalsTable);
            mw.animalsEntities.AnimalsTable.Add(animalsTable);
            mw.animalsEntities.SaveChanges();
            mw.ClearTextBox();
        }

        public void Clear(MainWindow mw)
        {
            for (int i = mw.OCAnimals.Count - 1; i >= 0; i--)
            {
                mw.animalsEntities.AnimalsTable.Remove(mw.OCAnimals[i]);
                mw.animalsEntities.SaveChanges();
                mw.OCAnimals.Remove(mw.OCAnimals[i]);
            }
        }

        public void Create(MainWindow mw)
        {
            CreateAnim.anim.Clear();
            CreateAnim.Create();
            foreach (var anim in CreateAnim.anim)
            {
                AnimalsTable animalsTable = new AnimalsTable();
                int nextId = 1;
                foreach (var anim1 in mw.OCAnimals)
                {
                    if (nextId <= int.Parse(anim1.Id))
                        nextId = int.Parse(anim1.Id) + 1;
                }
                animalsTable.Id = nextId.ToString();
                animalsTable.KindOfAnimal = anim.KindOfAnimal;
                animalsTable.Name = anim.Name;
                animalsTable.Age = anim.Age;
                animalsTable.Gender = anim.Gender;
                mw.OCAnimals.Add(animalsTable);
                mw.animalsEntities.AnimalsTable.Add(animalsTable);
                mw.animalsEntities.SaveChanges();
            }
        }

        public void Delete(string id, MainWindow mw)
        {
            for (int i = 0; i < mw.OCAnimals.Count; i++)
            {
                if (int.Parse(id) == int.Parse(mw.OCAnimals[i].Id))
                {
                    mw.animalsEntities.AnimalsTable.Remove(mw.OCAnimals[i]);
                    mw.animalsEntities.SaveChanges();
                    mw.ClearTextBox();
                    mw.LoadData();
                    break;
                }
            }
        }

        public void Update(string id, string kindOfAnimal, string name, string age, string gender, MainWindow mw)
        {
            for (int i = 0; i < mw.OCAnimals.Count; i++)
            {
                if (int.Parse(id) == int.Parse(mw.OCAnimals[i].Id))
                {
                    mw.OCAnimals[i].KindOfAnimal = kindOfAnimal;
                    mw.OCAnimals[i].Name = name;
                    mw.OCAnimals[i].Age = age;
                    mw.OCAnimals[i].Gender = gender;
                    mw.animalsEntities.SaveChanges();
                    mw.LoadData();
                    mw.ClearTextBox();
                    break;
                }
            }
        }
    }
}
