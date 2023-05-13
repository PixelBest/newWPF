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
        void Add(string kindOfAnimal, string name, string age, string gender, MainWindow mw);
        void Update(string id, string kindOfAnimal, string name, string age, string gender, MainWindow mw);
        void Delete(string id, MainWindow mw);
        void Clear(MainWindow mw);
        void Create(MainWindow mw);
    }
}
