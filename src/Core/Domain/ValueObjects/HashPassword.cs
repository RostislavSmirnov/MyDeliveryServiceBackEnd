using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public sealed record HashPassword
    {
        public string Value { get; } = null!;
        private HashPassword(string password) 
        {
            Value = password;
        }

        public HashPassword Create(string password) 
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("Пароль не может быть пустым");

            if (password.Length < 60) throw new ArgumentNullException("Некорректный хэш пароля");

            HashPassword createdHashedPassword = new(password);
            return createdHashedPassword;
        }

        public override string ToString() => Value;
    }
}
