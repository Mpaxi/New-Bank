using System.Collections.Generic;

namespace NB.CheckingAccount.Domain.ValueObjects
{
    public class CPF
    {
        public List<string> Failures { get; private set; }

        public string Value { get; private set; }
        public bool IsValid { get; private set; } = true;

        public CPF(string value)
        {
            this.Value = value;
            this.Validar();
            this.Failures = new List<string>();
        }

        void Validar()
        {
            if (string.IsNullOrEmpty(this.Value))
            {
                this.IsValid = false;
                this.Failures.Add("CPF Invalido");
            }
        }
    }
}
