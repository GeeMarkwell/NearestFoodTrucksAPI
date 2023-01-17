using Blazored.Toast.Services;

using qcashweb.ViewModels;
using Microsoft.AspNetCore.Components;

using System.Linq;

namespace qcashweb.Pages
{
    public partial class Index : ComponentBase
    {
        #region Injections
        [Inject]
        IToastService toastService { get; set; }
        #endregion
        public decimal Latitude { get; set; } 
        public decimal Longitude { get; set; }
        public bool ShowSpinner { get; set; }

        List<NearestTrucksViewModel> NearbyTruckList = new();
      
        protected void FindNearestFoodTrucks()
        {
            if (Latitude != 0 && Longitude != 0)
            {
              
                try
                {
                    NearbyTruckList = new();
                    var lines = File.ReadLines("/Users/user/Documents/gee/qcash/qcashweb/qcashweb/Pages/Mobile_Food_Facility_Permit.csv");
                    var i = 0;
                    foreach (string line in lines)
                    {
                        if (i != 0)
                        {

                            var values = line.Split(',');
                            NearestTrucksViewModel obj = new NearestTrucksViewModel();
                            obj.Locationid = values[0];
                            obj.Applicant = values[1];
                            obj.FacilityType = values[2];
                            obj.LocationDescription = values[4];
                            obj.Address = values[5];
                            obj.Status = values[10];
                            var lat = values[14];
                            decimal number1;
                            decimal number2;
                            if (Decimal.TryParse(values[14], out number1))
                            {
                                obj.Latitude = number1;
                            }
                            if (Decimal.TryParse(values[15], out number1))
                            {
                                obj.Longitude = number1;
                            }
                            obj.Distance = Math.Sqrt(Math.Pow(Convert.ToDouble((double)69.1 * (double)(obj.Latitude - Latitude)), 2) + Math.Pow(Convert.ToDouble((double)69.1 * (double)(Longitude - obj.Longitude) * Math.Cos((double)obj.Latitude / (double)57.3)), 2));

                            NearbyTruckList.Add(obj);

                        }
                        i = 1;

                    }
                    NearbyTruckList = NearbyTruckList.Where(x => x.Status == "APPROVED" && x.FacilityType == "Truck").OrderBy(x => x.Distance).ToList();
                    
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }

            }
            else
            {
                toastService.ShowError("PLEASE FILL ALL THE FIELDS FIRST");
            }
        }

    }
}


