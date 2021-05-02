using MyAspTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspTest.ViewModel
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; } // значение для сортировки по имени
        public SortState SurNameSort { get; set; }
        public SortState Current { get; set; }     // значение свойства, выбранного для сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortState sortOrder)
        {
            // значения по умолчанию
            NameSort = SortState.NameAsc;
            SurNameSort = SortState.SurNameAsc;
            Up = true;

            if (sortOrder == SortState.NameDesc || sortOrder == SortState.SurNameDesc)
            {
                Up = false;
            }

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                case SortState.SurNameDesc:
                    Current = SurNameSort = SortState.SurNameAsc;
                    break;
                case SortState.SurNameAsc:
                    Current = SurNameSort = SortState.SurNameDesc;
                    break;
                default:
                    Current = NameSort = SortState.NameDesc;
                    break;
            }
        }
    }
}

