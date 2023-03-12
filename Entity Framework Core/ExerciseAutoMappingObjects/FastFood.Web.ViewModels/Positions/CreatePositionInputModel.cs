namespace FastFood.Web.ViewModels.Positions
{
    using System.ComponentModel.DataAnnotations;
    using FastFood.Common.EntityConfiguration;

    public class CreatePositionInputModel
    {
        [MaxLength(ViewModelsValidation.PositionNameMaxLength)]
        [MinLength(ViewModelsValidation.PositionNameMinLength)]
        //[StringLength(ViewModelsValidation.PositionNameMaxLength, MinimumLength = ViewModelsValidation.PositionNameMinLength)]
        public string PositionName { get; set; } = null!;
    }
}