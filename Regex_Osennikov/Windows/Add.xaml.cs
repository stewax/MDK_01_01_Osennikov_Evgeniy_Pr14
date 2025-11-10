using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Regex_Osennikov.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Classes.Passport EditPassports;

        public Add(Classes.Passport EditPassports)
        {
            InitializeComponent();

            if (EditPassports != null)
            {
                Name.Text = EditPassports.Name;
                FirstName.Text = EditPassports.FirstName;
                LastName.Text = EditPassports.LastName;
                Issued.Text = EditPassports.Issued;
                DateOfIssued.Text = EditPassports.DateOfIssued;
                DepartmentCode.Text = EditPassports.DepartmentCode;
                SeriesAndNumber.Text = EditPassports.SeriesAndNumber;
                DateOfBirth.Text = EditPassports.DateOfBirth;
                PlaceOfBirth.Text = EditPassports.PlaceOfBirth;
                this.EditPassports = EditPassports;
                BthAdd.Content = "Изменить";
            }
        }

        public void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) || !Regex.IsMatch(Name.Text, @"^[а-яА-ЯёЁ\s\-]+$"))
            {
                MessageBox.Show("Неправильно указано имя пользователя");
                return;
            }

            if (string.IsNullOrWhiteSpace(FirstName.Text) || !Regex.IsMatch(FirstName.Text, @"^[а-яА-ЯёЁ\s\-]+$"))
            {
                MessageBox.Show("Неправильно указана фамилия пользователя");
                return;
            }

            if (string.IsNullOrWhiteSpace(LastName.Text) || !Regex.IsMatch(LastName.Text, @"^[а-яА-ЯёЁ\s\-]+$"))
            {
                MessageBox.Show("Неправильно указано отчество пользователя");
                return;
            }

            if (string.IsNullOrWhiteSpace(Issued.Text) || !Regex.IsMatch(Issued.Text, @"^[а-яА-ЯёЁ0-9\s\-\.\,\(\)«»""\/]+$"))
            {
                MessageBox.Show("Некорректно указано, кем выдан паспорт");
                return;
            }

            if (string.IsNullOrWhiteSpace(DateOfIssued.Text) || !DateTime.TryParseExact(DateOfIssued.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат даты выдачи (ожидается дд.мм.гггг)");
                return;
            }

            if (string.IsNullOrWhiteSpace(DepartmentCode.Text) || !Regex.IsMatch(DepartmentCode.Text, @"^\d{3}-?\d{3}$"))
            {
                MessageBox.Show("Неверный формат кода подразделения (пример: 777-777 или 777777)");
                return;
            }

            string cleanSeriesNumber = Regex.Replace(SeriesAndNumber.Text, @"\s+", "");
            if (string.IsNullOrWhiteSpace(SeriesAndNumber.Text) || cleanSeriesNumber.Length != 10 || !long.TryParse(cleanSeriesNumber, out _))
            {
                MessageBox.Show("Серия и номер паспорта должны содержать 10 цифр (например: 12 34 567890)");
                return;
            }

            if (string.IsNullOrWhiteSpace(DateOfBirth.Text) || !DateTime.TryParseExact(DateOfBirth.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат даты рождения (ожидается дд.мм.гггг)");
                return;
            }

            if (string.IsNullOrWhiteSpace(PlaceOfBirth.Text) || !Regex.IsMatch(PlaceOfBirth.Text, @"^[а-яА-ЯёЁ0-9\s\-\.\,\(\)\/]+$"))
            {
                MessageBox.Show("Некорректно указано место рождения");
                return;
            }

            if (EditPassports == null)
            {
                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
            }


            EditPassports.Name = Name.Text;
            EditPassports.FirstName = FirstName.Text;
            EditPassports.LastName = LastName.Text;
            EditPassports.Issued = Issued.Text;
            EditPassports.DateOfIssued = DateOfIssued.Text;
            EditPassports.DepartmentCode = DepartmentCode.Text;
            EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
            EditPassports.DateOfBirth = DateOfBirth.Text;
            EditPassports.PlaceOfBirth = PlaceOfBirth.Text;

            MainWindow.init.LoadPassports();

            this.Close();
        }
    }
}
