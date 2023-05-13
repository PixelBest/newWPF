using newWPF.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newWPF.View
{
    delegate void DeleteAnimation();
    delegate void AddAnimation();
    delegate void UpdateAnimation();    //делегаты для действий с базой данных
    delegate void ClearAnimation();
    delegate void CreateAnimation();
    internal interface IAnimalsView
    {
        string IdText { get; set; }
        string KindOfAnimalsText { get; set; }
        string NameText { get; set; }       //свойства для TextBox-ов
        string AgeText { get; set; }
        string GenderText { get; set; }

        ObservableCollection<AnimalsTable> ListAnimals { get; set; }
        AnimalsEntities AnimEnt { get; }
        event DeleteAnimation DeleteAnimEvent;
        event AddAnimation AddAnimaEvent;
        event UpdateAnimation UpdateAnimEvent;      //события для действий с базой данных
        event ClearAnimation ClearAnimEvent;
        event CreateAnimation CreateAnimEvent;

        void LoadData();
        void ClearTextBox();
    }
}
