﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Nexul.Demo.MvcWeb.Models
{
    public class ValidationStateModel
    {
        public string Message { get; set; }
        public List<ValidationError> Errors { get; set; }

        public ValidationStateModel() { }

        public ValidationStateModel(string genericError)
        {
            Message = genericError;
        }
        public ValidationStateModel(IEnumerable<string> genericErrors)
        {
            Message = string.Join('.', genericErrors.Distinct());
        }
        public ValidationStateModel(IEnumerable<ValidationError> errors)
        {
            Errors = errors.ToList();
        }
        public ValidationStateModel(ModelStateDictionary modelState)
        {
            var genericErrors = modelState.Keys
                .Where(key => string.IsNullOrWhiteSpace(key))
                .Select(key => modelState[key].Errors.Select(x => x.ErrorMessage))
                .ToList();

            Message = genericErrors.Count == 0 ? "Validation failed"
                : string.Join('.', genericErrors.Distinct());
            Errors = modelState.Keys
                .Where(key => !string.IsNullOrWhiteSpace(key))
                .SelectMany(key => modelState[key].Errors
                    .Select(x => new ValidationError { PropertyName = key, Message = x.ErrorMessage }))
                .ToList();
        }
    }
}
