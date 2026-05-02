using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace eBIR_Forms_RE.viewModels
{
    public class TinInputViewModel : INotifyPropertyChanged
    {
        private string? _tin;
        public string? TIN
        {
            get => _tin;
            set
            {
                if (_tin != value)
                {
                    string formatted = FormatTin(value);
                    if (_tin != formatted)
                    {
                        _tin = formatted;
                        OnPropertyChanged(nameof(TIN));
                    }
                }
            }
        }

        private string FormatTin(string? input)
        {
            if(string.IsNullOrEmpty(input))
                return string.Empty;
            string digits = new string(input.Where(char.IsDigit).ToArray());

            if (digits.Length > 14)
            {
             digits = digits.Substring(0, 14);   
            }

            if (digits.Length <= 3)
            {
                return digits;
            }

            if (digits.Length <= 6)
            {
                return digits.Insert(3, "-");
            }
            if (digits.Length <= 9)
            {
                return digits.Insert(6, "-");
            }
            return digits.Insert(9, "-").Insert(6, "-").Insert(3, "-");
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}