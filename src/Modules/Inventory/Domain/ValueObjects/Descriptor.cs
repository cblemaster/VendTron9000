
using System.Text.RegularExpressions;

namespace Modules.Inventory.Domain.ValueObjects;

internal sealed class Descriptor
{
    internal string Value { get; init; }

    internal Descriptor(string value, uint maxLength, bool isRequired, bool isAllowAllWhitespace, string? regexPattern)
    {
        if (isRequired && string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Value is required...", nameof(value));
        }
        
        if (!isAllowAllWhitespace && Regex.Match(value, @"\s$").Success)
        {
            throw new ArgumentException("Value must not be all whitespace characters...", nameof(value));
        }

        if (value.Length > maxLength)
        {
            throw new ArgumentException($"Value must be fewer than {maxLength} characters in length...", nameof(value));
        }

        if (regexPattern is not null && !Regex.Match(value, regexPattern).Success)
        {
            throw new ArgumentException($"Value must be formatted properly...", nameof(value));
        }

        Value = value;
    }
}
