using System;
using System.Collections.Generic;
using System.Text;

namespace GridViewSimple.ViewModel
{
    using System.Collections.ObjectModel;
    using GridViewSimple.Model;

    public class GridViewVM
    {
        public ObservableCollection<DataObject> SourceList { get; set; }

        public GridViewVM()
        {
            InitiateSourceList();
        }

        private void InitiateSourceList()
        {
            SourceList = new ObservableCollection<DataObject>()
            {
                new DataObject()
                {
                    FirstName = "Petr",
                    Surname = "Zavodny",
                    Age = 40
                },
                new DataObject()
                {
                    FirstName = "Ondra",
                    Surname = "Pichal",
                    Age = 2
                },
                new DataObject()
                {
                    FirstName = "Jarmila",
                    Surname = "Plaziva",
                    Age = 105
                },
            };
        }
    }
}
