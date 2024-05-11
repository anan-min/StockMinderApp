namespace StockMinderApp.Views;

public partial class AddProductPage : ContentPage
{
    string _photoPath;
    public AddProductPage()
	{
		InitializeComponent();
	}



    async void btnCameraRoll_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            PermissionStatus status = await CheckAndRequestPhotosPermission();
            if (status == PermissionStatus.Granted || status == PermissionStatus.Limited)
            {
                var photo = await MediaPicker.Default.PickPhotoAsync();
                _photoPath = await LoadPhotoAsync(photo); // Store the path in _photoPath

                Console.WriteLine(_photoPath);
                Console.WriteLine(_photoPath);
                Console.WriteLine(_photoPath);
                Console.WriteLine(_photoPath);
                Console.WriteLine(_photoPath);
                Console.WriteLine(_photoPath);

                if (!string.IsNullOrEmpty(_photoPath))
                {
                    string nmFile = Path.GetFileName(_photoPath);
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        ProductImage.Source = ImageSource.FromFile(_photoPath);
                        await Share.Default.RequestAsync(new ShareFileRequest
                        {
                            Title = Title,
                            File = new ShareFile(_photoPath)
                        });
                    });
                }

            }
        }





        catch (FeatureNotSupportedException fnsEx) // Feature is not supported on the device
        {
            await DisplayAlert("Feature Not Supported", fnsEx.Message, "OK");
        }
        catch (PermissionException pEx) // Permissions not granted
        {
            await DisplayAlert("Permission Error", pEx.Message, "OK");
        }
        catch (Exception ex) // Error Unexpected
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }


    public async Task<PermissionStatus> CheckAndRequestPhotosPermission()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Photos>(); if (status == PermissionStatus.Granted)
        {
            return status;
        }
        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Prompt the user to turn on in settings On iOS once a
            // permission has been denied it may not be requested again from // the application
            return status;
        }
        if (Permissions.ShouldShowRationale<Permissions.Photos>())
        {
        }
        status = await Permissions.RequestAsync<Permissions.Photos>(); return status;
    }

    async Task<string> LoadPhotoAsync(FileResult photo)
    {
        // canceled
        if (photo == null)
        {
            return "";
        }
        // save the file into local storage
        string newFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName); using Stream sourceStream = await photo.OpenReadAsync();
        using FileStream fileStream = File.OpenWrite(newFilePath);
        await sourceStream.CopyToAsync(fileStream); // Copy Source Stream to new Stream
        return newFilePath;
    }

    async void btnCamera_Clicked(System.Object sender, System.EventArgs e)
    {
        await TakePhotoAsync();
    }

    async Task TakePhotoAsync()
    {
        PermissionStatus status = await CheckAndRequestPhotosPermission();
        if (status == PermissionStatus.Granted || status == PermissionStatus.Limited)
        {
            try
            {
                var photo = await MediaPicker.Default.CapturePhotoAsync();
                _photoPath = await LoadPhotoAsync(photo);
                if (_photoPath != "")
                    MainThread.BeginInvokeOnMainThread(() => {
                        ProductImage.Source = ImageSource.FromFile(_photoPath);
                    });
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Feature Not Supported", ex.Message, "OK");
            }
            catch (PermissionException ex)
            {
                await DisplayAlert("Permission Error", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
