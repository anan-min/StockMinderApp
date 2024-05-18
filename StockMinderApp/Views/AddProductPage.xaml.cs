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

    private async void SubmitProductClicked(System.Object sender, System.EventArgs e)
    {
        // all form need to be filled
        // check of the product id if it already exist 
        // image holder will be used if image is not upload
        if (AreEntriesEmpty())
        {
            await DisplayAlert("Alert", "Please fill in all fields", "OK");
            FocusFirstEmptyEntry();
        }
        else
        {
            bool isProductIdExisted = await App.productDatabase.isProductIdExisted(ProductIdEntry.Text);

            if (isProductIdExisted)
            {
                await DisplayAlert("Alert", "Product Id is already exist", "OK");
                ClearAndFocusEntry(ProductIdEntry);
            }
            else if(!TryParseStockLevel(out _)){
                await DisplayAlert("Alert", "Stock Level must be a valid number", "OK");
                StockLevelEntry.Text = "";
                StockLevelEntry.Focus();
            }
            else
            {
                await DisplayAlert("Alert", "Product Submitted", "OK");

                await App.productDatabase.InsertProductAsync(
                     ProductIdEntry.Text,
                     ProductNameEntry.Text,
                     ProductDescriptionEntry.Text,
                     int.Parse(StockLevelEntry.Text),
                     StockLocationEntry.Text,
                     _photoPath
                 );
                await Navigation.PushAsync(new ProductsPage());
            }

        }

    }


    private bool TryParseStockLevel(out int stockLevel)
    {
        return int.TryParse(StockLevelEntry.Text, out stockLevel);
    }





    private void FocusFirstEmptyEntry()
    {
        if (string.IsNullOrWhiteSpace(ProductIdEntry.Text))
        {
            ProductIdEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(ProductNameEntry.Text))
        {
            ProductNameEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(StockLevelEntry.Text))
        {
            StockLevelEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(StockLocationEntry.Text))
        {
            StockLocationEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(ProductDescriptionEntry.Text))
        {
            ProductDescriptionEntry.Focus();
        }

    }


    private bool AreEntriesEmpty()
    {
        return string.IsNullOrWhiteSpace(ProductIdEntry.Text)
                || string.IsNullOrWhiteSpace(ProductNameEntry.Text)
                || string.IsNullOrWhiteSpace(StockLevelEntry.Text)
                || string.IsNullOrWhiteSpace(StockLocationEntry.Text)
                || string.IsNullOrWhiteSpace(ProductDescriptionEntry.Text);
    }


    private void ClearAndFocusEntry(Entry entry)
    {
        entry.Text = "";
        entry.Focus();
    }

}
