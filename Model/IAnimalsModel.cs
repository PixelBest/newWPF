using newWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newWPF.Model
{
    internal interface IAnimalsModel
    {
        void Add(string kindOfAnimal, string name, string age, string gender, IAnimalsView view);
        void Update(string id, string kindOfAnimal, string name, string age, string gender, IAnimalsView view);
        void Delete(string id, IAnimalsView view);          //методы для действий с базой данных
        void Clear(IAnimalsView view);
        void Create(IAnimalsView view);
    }
}
