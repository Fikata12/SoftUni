using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.DataConstants.Task;
using TaskBoardApp.Web.ViewModels.Board;

namespace TaskBoardApp.Web.ViewModels.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, 
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<SelectBoardViewModel>? Boards { get; set; }
    }
}
