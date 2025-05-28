using System.ComponentModel.DataAnnotations;

namespace VacationAccountingSystem.Data
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля составляет 6 символов")]
        public string? Password { get; set; }

    }
}
