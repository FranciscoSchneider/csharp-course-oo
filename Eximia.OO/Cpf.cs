namespace Eximia.OO
{
    public struct Cpf
    {
        private readonly string _value;

        public Cpf(string value) => _value = value;

        public static Cpf Parse(string value)
           => TryParse(value, out var result)
             ? result
             : throw new ArgumentException(nameof(value));

        public static bool TryParse(string value, out Cpf result)
        {
            if (string.IsNullOrEmpty(value) || !IsValid(value))
            {
                result = default;
                return false;
            }

            result = new Cpf(value);
            return true;
        }

        public static implicit operator Cpf(string value) => Parse(value);
        public override string ToString() => _value;
        public bool IsEmpty => _value == null;

        public static bool IsValid(string value)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "");
            if (value.Length != 11)
                return false;
            tempCpf = value.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return value.EndsWith(digito);
        }
    }
}
