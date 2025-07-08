using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ClassError
    {
        public void Error_001()
        {
            MessageBox.Show("Виберіть запис", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error_002()
        {
            MessageBox.Show("Не правильно вказані данні для пошуку", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error_003()
        {
            MessageBox.Show("Заповніть всі поля!", "Error");
        }

        public void Error_004()
        {
            MessageBox.Show("Не закривайте вікно тому що файл не буде записаній до кінця", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error_005()
        {
            MessageBox.Show("Вітаємо", "Запуск программи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error_006()
        {
            MessageBox.Show("Не вірне им'я користувача або пароль");
        }

        public void Error_007()
        {
            MessageBox.Show("Данних не знайдено");
        }
    }
}
