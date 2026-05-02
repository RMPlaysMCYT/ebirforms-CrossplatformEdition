using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace eBIR_Forms_RE.viewModels
{
    public class TinInputViewModel : INotifyPropertyChanged
    {
        private string _part1 = string.Empty;
        private string _part2 = string.Empty;
        private string _part3 = string.Empty;
        private string _part4 = string.Empty;

        public string Part1
        {
            get => _part1;
            set => SetTinPart(ref _part1, value, 3);
        }

        public string Part2
        {
            get => _part2;
            set => SetTinPart(ref _part2, value, 3);
        }

        public string Part3
        {
            get => _part3;
            set => SetTinPart(ref _part3, value, 3);
        }

        public string Part4
        {
            get => _part4;
            set => SetTinPart(ref _part4, value, 5);
        }

        public string FullTIN 
        {
            get
            {
                return $"{Part1}-{Part2}-{Part3}-{Part4}".TrimEnd('-');
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void SetTinPart(ref string field, string? value, int maxLength, [CallerMemberName] string? propertyName = null)
        {
            string sanitized = new string((value ?? string.Empty).Where(char.IsDigit).ToArray());
            
            if (sanitized.Length > maxLength)
            {
                sanitized = sanitized.Substring(0, maxLength);
            }
            if (field != sanitized)
            {
                field = sanitized;
                OnPropertyChanged(propertyName);
                
                OnPropertyChanged(nameof(FullTIN));
            }
        }
    }
}