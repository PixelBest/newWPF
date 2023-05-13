using newWPF.DataBase;
using newWPF.Model;
using newWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace newWPF.Presenter
{
    internal class AnimalsPresenter
    {
        private IAnimalsView view;
        private MainWindow mw;

        public AnimalsPresenter(IAnimalsView view)
        {
            this.mw = view as MainWindow; 
            this.view = view;
            view.AddAnim += Add;
            view.UpdateAnim += Update;
            view.DeleteAnim += Delete;
            view.ClearAnim += Clear;
            view.CreateAnim += Create;
        }

        private void Add(object sender, EventArgs e)
        {
            AnimalsTable animalsTable = new AnimalsTable();
            animalsTable.Id = Convert.ToString(mw.animalsEntities.AnimalsTable.Count() + 1);
            animalsTable.KindOfAnimal = view.KindOfAnimalsText;
            animalsTable.Name = view.NameText;
            animalsTable.Age = view.AgeText;
            animalsTable.Gender = view.GenderText;
            mw.OCAnimals.Add(animalsTable);
            mw.animalsEntities.AnimalsTable.Add(animalsTable);
            mw.animalsEntities.SaveChanges();
            mw.ClearTextBox();
        }

        private void Update(object sender, EventArgs e)
        {
            mw.OCAnimals[int.Parse(view.IdText) - 1].KindOfAnimal = view.KindOfAnimalsText;
            mw.OCAnimals[int.Parse(view.IdText) - 1].Name = view.NameText;
            mw.OCAnimals[int.Parse(view.IdText) - 1].Age = view.AgeText;
            mw.OCAnimals[int.Parse(view.IdText) - 1].Gender = view.GenderText;
            mw.animalsEntities.SaveChanges();
            mw.LoadData();
            mw.ClearTextBox();
        }

        private void Delete(object sender, EventArgs e)
        {
            for (int i = 0; i < mw.OCAnimals.Count; i++)
            {
                if (int.Parse(view.IdText) == int.Parse(mw.OCAnimals[i].Id))
                {
                    mw.animalsEntities.AnimalsTable.Remove(mw.OCAnimals[i]);
                }
            }
            mw.ClearTextBox();
            mw.animalsEntities.SaveChanges();
            mw.LoadData();
        }
        private void Clear(object sender, EventArgs e)
        {
            for (int i = mw.OCAnimals.Count - 1; i >= 0; i--)
            {
                mw.animalsEntities.AnimalsTable.Remove(mw.OCAnimals[i]);
                mw.animalsEntities.SaveChanges();
                mw.OCAnimals.Remove(mw.OCAnimals[i]);
            }
        }
        private void Create(object sender, EventArgs e)
        {
            CreateAnim.anim.Clear();
            CreateAnim.Create();
            foreach (var anim in CreateAnim.anim)
            {
                AnimalsTable animalsTable = new AnimalsTable();
                animalsTable.Id = Convert.ToString(mw.animalsEntities.AnimalsTable.Count() + 1);
                animalsTable.KindOfAnimal = anim.KindOfAnimal;
                animalsTable.Name = anim.Name;
                animalsTable.Age = anim.Age;
                animalsTable.Gender = anim.Gender;
                mw.OCAnimals.Add(animalsTable);
                mw.animalsEntities.AnimalsTable.Add(animalsTable);
                mw.animalsEntities.SaveChanges();
            }
        }
    }
}
