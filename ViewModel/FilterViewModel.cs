using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspTest.Models;

namespace MyAspTest.ViewModel
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Position> positions, int? position, List<Status> statuses, int? status, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            positions.Insert(0, new Position {  Id = 0, Name = "Все" });
            statuses.Insert(0, new Status { Id = 0, Name = "Все"});
            Statuses = new SelectList(statuses, "Id", "Name", status);
            Positions = new SelectList(positions, "Id", "Name", position);
            SelectedStatus = status;
            SelectedPosition = position;
            SelectedName = name;
        }
        public SelectList Positions { get; private set; } 
        public SelectList Statuses { get; private set; }
        public int? SelectedPosition { get; private set; }   
        public int? SelectedStatus { get; private set; }
        public string SelectedName { get; private set; }    
    }
}
