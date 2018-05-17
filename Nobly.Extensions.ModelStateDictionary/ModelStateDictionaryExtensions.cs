using System;

namespace Nobly.Extensions.ModelStateDictionary
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddErrorMessage(this Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState, string error)
        {
            modelState.AddModelError("msg", error);
        }

    }
}
