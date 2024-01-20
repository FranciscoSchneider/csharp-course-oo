namespace Eximia.OO
{
    public record struct Address(
        string Street,
        string Number,
        string Neighborhood,
        string PostalCode,
        string City,
        string Complement = "");
}
