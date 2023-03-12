namespace FastFood.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;
    using FastFood.Common.EntityConfiguration;

    public class CreateCategoryInputModel
    {
        [MinLength(ViewModelsValidation.CategoryNameMinLength)]
        [MaxLength(ViewModelsValidation.CategoryNameMaxLength)]
        public string CategoryName { get; set; } = null!;
    }
}
