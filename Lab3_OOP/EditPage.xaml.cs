using System.Collections.ObjectModel;

namespace Lab3_OOP
{
    public partial class EditPage : ContentPage
    {
        private ScientificWork _selectedItem;
        public event EventHandler<ScientificWork> DataModified;

        private void FillInputs()
        {
            nameInput.Text = _selectedItem.Name;
            authorNameInput.Text = _selectedItem.AuthorName;
            facultyInput.Text = _selectedItem.Faculty;
            departInput.Text = _selectedItem.Department;
            labInput.Text = _selectedItem.Labaratory;
            posInput.Text = _selectedItem.AuthorPosition;
            startOnInput.Text = _selectedItem.StartOnPosition;
            lastOnInput.Text = _selectedItem.LastonPosition;
            custNameInput.Text = _selectedItem.CustomerName;
            custAdrInput.Text = _selectedItem.CustomerAdress;
            submInput.Text = _selectedItem.Submission;
            branchInput.Text = _selectedItem.Branch;
        }
        public EditPage(ScientificWork selected)
        {
            InitializeComponent();

            _selectedItem = selected;
            FillInputs();
        }

        private bool ValidateYear(string value)
        {
            if (int.TryParse(value, out int year))
            {
                if (year >0 && year <= 2023)
                {
                    return true;
                }     
            }
            return false;
        }
        
        private bool IsEmpty(string value) 
        {
            return value == string.Empty;
        }

        private bool ValidateAll()
        {
            return (
                !IsEmpty(nameInput.Text) &&
                !IsEmpty(authorNameInput.Text)&&
                !IsEmpty(facultyInput.Text)&&
                !IsEmpty(departInput.Text)&&
                !IsEmpty(labInput.Text)&&
                !IsEmpty(posInput.Text)&&
                !IsEmpty(startOnInput.Text)&&
                ValidateYear(startOnInput.Text)&&
                ValidateYear(lastOnInput.Text)&&
                !IsEmpty(lastOnInput.Text)&&
                !IsEmpty(custNameInput.Text)&&
                !IsEmpty(custAdrInput.Text)&&
                !IsEmpty(submInput.Text)&&
                !IsEmpty(branchInput.Text)
                );
        }

        private void UpdateSelected()
        {
            _selectedItem.Name = nameInput.Text;
            _selectedItem.AuthorName = authorNameInput.Text;
            _selectedItem.Faculty = facultyInput.Text;
            _selectedItem.Department = departInput.Text;
            _selectedItem.Labaratory = labInput.Text;
            _selectedItem.AuthorPosition = posInput.Text;
            _selectedItem.StartOnPosition = startOnInput.Text;
            _selectedItem.LastonPosition = lastOnInput.Text;
            _selectedItem.CustomerName = custNameInput.Text;
            _selectedItem.CustomerAdress = custAdrInput.Text;
            _selectedItem.Submission = submInput.Text;
            _selectedItem.Branch = branchInput.Text;
        }
        private void SaveButtonClicked(object sender, EventArgs e)
        {
            if (ValidateAll())
            {
                UpdateSelected();
                DataModified?.Invoke(this, _selectedItem);
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Помилка", "Деякі введення не валідні.", "ОК");
            }
        }

        private void ReturnButtonClicked(object sender, EventArgs e)
        {
                Navigation.PopModalAsync();
        }
    }
}
