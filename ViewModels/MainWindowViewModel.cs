using System.Collections.ObjectModel;
using eBIR_Forms_RE.viewModels;
using eBIR_Forms_RE.Views;

namespace eBIR_Forms_RE.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public TinInputViewModel TinSection { get; } = new TinInputViewModel();
    public string Greeting { get; } = "eBIR Forms RE";
    public string AppInfo { get; } = "Recreated by RMPlaysMCYT, Using Avalonia";
    public string GovtInfo { get; } = "Government Property, NOT FOT SALE";

    public string TaxpayerName { get; } =
        "Taxpayer’s Name (Last Name, First Name and Middle Name For Individual)\nRegistered Name (For Non-Individual)";

    public string FormType { get; } = "Choose a Type of BIR Forms";

    public string selectedRegionalLists { get; set; }
    public ObservableCollection<string> RegionalLists { get; } = new ObservableCollection<string>
    {
        "SELECT A RDO Branch",
        "RDO 001 - Laoag",
        "RDO 002 - Vigan",
        "RDO 003 - San Fernando",
        "RDO 004 - Calasiao",
        "RDO 005 - Alaminos City",
        "RDO 006 - Urdaneta City",
        "RDO 007 - Bangued",
        "RDO 008 - Baguio City",
        "RDO 009 - La Trinidad",
        "RDO 010 - Bontoc"
    };
    
    public string SelectedForm { get; set; }

    public ObservableCollection<string> Forms { get; } = new ObservableCollection<string>
    {
        "Choose a Type of BIR Forms",
        "Income Tax Return",
        "Witholding Tax Return",
        "VAT and Percentage Tax Return",
        "Payment Forms",
        "Document Stamp Tax"
    };

    public void ExitApp()
    {
        System.Environment.Exit(0);
    }
}