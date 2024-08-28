using RestSharp;
using System.Collections.ObjectModel;
using Taxi.App.Common;
using Taxi.App.Models;

namespace Taxi.App.ViewModels;

public class StartEndShiftViewModel
{
    public ObservableCollection<CarDTO> Cars { get; set; }
    public MProp<CarDTO> SelectedCar { get; set; } = new MProp<CarDTO>();
    public MProp<int> MileageStart { get; set; } = new MProp<int>();

    public StartEndShiftViewModel()
    {
        var request = new RestRequest("cars");
        var response = Api.Client.Execute<List<CarDTO>>(request);
        
        Cars = new ObservableCollection<CarDTO>(response.Data);
        SelectedCar.Value = Cars.FirstOrDefault();
    }
}
