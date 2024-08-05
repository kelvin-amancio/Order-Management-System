using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OrderManagement.API.ViewModels
{
    public static class ErrosViewModel
    {
        public static IList<string> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            foreach (var model in modelState.Values)
                errors.AddRange(model.Errors.Select(error => error.ErrorMessage));

            return errors;
        }
    }
}
