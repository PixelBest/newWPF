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
        private IAnimalsModel model;

        public AnimalsPresenter(IAnimalsView view)
        {
            this.mw = view as MainWindow; 
            this.view = view;
            model = new AnimalsModel();
            view.AddAnimaEvent += Add;
            view.UpdateAnimEvent += Update;
            view.DeleteAnimEvent += Delete;
            view.ClearAnimEvent += Clear;
            view.CreateAnimEvent += Create;
            view.SaveDataEvent += Save;
        }

        private void Add()
            => model.Add(view.AddKindOfAnimalsText, view.AddNameText, view.AddAgeText, view.AddGenderText, view);   //добавление животных в базу данных

        private void Update()
            => model.Update(view.UpdateIdText, view.UpdateAddKindOfAnimalsText, view.UpdateAddNameText, view.UpdateAddAgeText, view.UpdateAddGenderText, view);   //обновление животных в базе данных

        private void Delete()
            => model.Delete(view.DeleteIdText, view);   //удаление животных из базы данных

        private void Clear()
            => model.Clear(view);       //очистка ListView

        private void Create()       
            => model.Create(view);      //создание 6 животных в базу данных

        private void Save()
            => model.Save(view);    //сохранение коллекции в файл
    }
}