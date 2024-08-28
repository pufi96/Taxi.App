using FluentValidation.Results;

namespace Taxi.App.Common;

public static class ValidationExtensions
{
    public static string? GetError(this ValidationResult result, string property)
    {
        return result.Errors.FirstOrDefault(x => x.PropertyName == property + ".Value")?.ErrorMessage;
    }
}
