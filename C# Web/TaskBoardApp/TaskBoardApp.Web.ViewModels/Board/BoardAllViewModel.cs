namespace TaskBoardApp.Web.ViewModels.Board
{
    using System.Collections.Generic;

    using Task;

    public class BoardAllViewModel
    {
        public string Name { get; set; } = null!;

        public ICollection<TaskViewModel> Tasks { get; set; } = null!;
    }
}
