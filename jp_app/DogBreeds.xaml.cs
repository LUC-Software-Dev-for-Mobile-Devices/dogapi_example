using System.Collections.ObjectModel;
using jp_app.Models;
using System.Text.Json;


namespace jp_app;

public partial class DogBreeds : ContentPage
{
    private static string entryFormText;
    static string EntryFormText = "boxer";
    ObservableCollection<ImageData> result;
    
    //constructor
    public DogBreeds()
    {
        InitializeComponent();
        Task.Run(async () =>
        {

            result = await getDogBreedsFromAPI();
            if (result != null)
            {
                imagelist.ItemsSource = result;
            }



        }).Wait();


    }

    public static async Task<ObservableCollection<ImageData>> getDogBreedsFromAPI()
    {

        //string URL = String.Format("https://dog.ceo/api/breed/{0}/images", EntryFormText );
        string URL = String.Format("https://dog.ceo/api/breed/{0}/images", EntryFormText);

        HttpClient httpClient = new HttpClient();
        ObservableCollection<ImageData> imageList = new ObservableCollection<ImageData>();



        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(URL); //Sends a GET Request 
            string jsonContent = await response.Content.ReadAsStringAsync();
            Breeds abreed = JsonSerializer.Deserialize<Breeds>(jsonContent);
            foreach (var breed in abreed.message)
            {
                imageList.Add(new ImageData(breed));
            }

            return imageList;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    private void breedSubmission(object sender, EventArgs e)
    {
        EntryFormText = entryForm.Text;

        imagelist.ItemsSource = result;
        

    }
}

