using Common.Domain.Exceptions;
using Common.Domain.Utils;

namespace Common.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 11 || value.IsText())
            throw new InvalidDomainDataException("Invalid phone number ");
        Value = value;
    }

    public string Value { get; private set; }
}