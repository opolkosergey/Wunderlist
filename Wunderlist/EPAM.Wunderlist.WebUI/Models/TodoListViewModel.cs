﻿namespace EPAM.Wunderlist.WebUI.Models
{
    public class TodoListViewModel
    {
        public int Id { get; protected set; }
        public int UserModelId { get; set; }
        public string Name { get; set; }
        public int CountItem { get; set; }
    }
}