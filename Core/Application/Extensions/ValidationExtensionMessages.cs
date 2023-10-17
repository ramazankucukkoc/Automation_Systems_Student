namespace Core.Application.Extensions
{
    public static class ValidationExtensionMessages
    {
        public const string PasswordEmpty = "Parola Alanı Boş Olamaz!";
        public const string PasswordMinumumLength = "Parola Alanı Minimum 8 Karakter Uzunluğunda Olmalıdır!";
        public const string PasswordMaximumLength = "PArola Alanı Maksimum 16 Karakter Uzunluğunda Olmalıdır!";
        public const string PasswordUppercaseLetter = "Parola En Az 1 Büyük Harf İçermeledir!";
        public const string PasswordLowercaseLetter = "Parola En Az 1 Küçük Harf İçermeledir!";
        public const string PasswordDigit = "Parola En Az 1 Rakam İçermeledir!";
        public const string PasswordSpecialCharacter = "Parola En Az 1 Simge (*?/+- vs) İçermelidir!";

        public const string PhoneEmpty = "Telefon Numarası Alanı Boş Olamaz!";
        public const string PhoneLength = "Başında 0 olmadan ve Minimum 10 Karakter Uzunluğunda Olmalıdır!";
        public const string PhoneSpecialCharacter = "Tel No Alanına Lütfen  5 ile başlamalısınız!";

        public const int MinumumPhoneLenght = 10;
    }
}
