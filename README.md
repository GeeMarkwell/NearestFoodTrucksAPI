This is a Blazor web application that is used to find the nearest food trucks based on the user's current location. 

FindNearestFoodTrucks finds the closest food trucks when the user submits their location. It checks if the Latitude and Longitude have been provided by the user before proceeding.

If the user's location is provided, this method reads a file containing food truck information, creates a list of objects and populates them with the file data. It also calculates the distance between the user and each truck, and adds these objects to a list called NearbyTruckList.

The method will only display the trucks that have been approved, of type "Truck" and sorts them by distance. If location is not provided, it will show an error message to the user.


SELF CRITISM, if more time I WOULD & NEXT TIME i WILL...

Create a more robust and maintainable way to read the CSV file, can use a library specifically designed for reading CSV files, instead of using the 'File' class.
Validate the user input before using it to avoid exception, also add some user feedback to show that they need to fill in the specific fields.
Read CSV file more dynamically to read from a configuration file
Add a cache to prevent re-reading.
