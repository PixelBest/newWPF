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
    delegate void SaveData();
    internal interface IAnimalsView
    {
        string AddKindOfAnimalsText { get; set; }
        string AddNameText { get; set; }       //свойства для TextBox-ов
        string AddAgeText { get; set; }
        string AddGenderText { get; set; }
        string UpdateIdText { get; set; }
        string UpdateAddKindOfAnimalsText { get; set; }
        string UpdateAddNameText { get; set; }       //свойства для TextBox-ов
        string UpdateAddAgeText { get; set; }
        string UpdateAddGenderText { get; set; }
        string DeleteIdText { get; set; }

        ObservableCollection<AnimalsTable> ListAnimals { get; set; }
        AnimalsEntities AnimEnt { get; }
        event DeleteAnimation DeleteAnimEvent;
        event AddAnimation AddAnimaEvent;
        event UpdateAnimation UpdateAnimEvent;      //события для действий с базой данных
        event ClearAnimation ClearAnimEvent;
        event CreateAnimation CreateAnimEvent;
        event SaveData SaveDataEvent;

        void LoadData();
        void ClearTextBox();
    }
}
