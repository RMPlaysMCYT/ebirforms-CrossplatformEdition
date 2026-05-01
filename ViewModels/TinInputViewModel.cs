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
                return input?? "";
            var digits = input.Replace("-", "").Replace(" ", "");
        
            digits = new string(digits.Where(char.IsDigit).ToArray());
            return string.Join("-", Enumerable.Range(0, digits.Length / 3 + (digits.Length % 3 == 0 ? 0 : 1))
                .Select(i => digits.Skip(i * 3).Take(3))
                .Where(g => g.Any())
                .Select(g => new string(g.ToArray())));
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}