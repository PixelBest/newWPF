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
        }

        private void Add()
            => model.Add(view.KindOfAnimalsText, view.NameText, view.AgeText, view.GenderText, view);

        private void Update()
            => model.Update(view.IdText, view.KindOfAnimalsText, view.NameText, view.AgeText, view.GenderText, view);

        private void Delete()
            => model.Delete(view.IdText, view);

        private void Clear()
            => model.Clear(view);

        private void Create()
            => model.Create(view);
    }
}