﻿namespace EventServer.Models
{
    using System.Web.Mvc;

    using EventServer.Core.Domain;

    public class PresentationCategoryBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            SessionCategory category = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
            return category;
        }
    }
}