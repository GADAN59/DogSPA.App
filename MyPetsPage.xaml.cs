namespace DogSPA;

public partial class MyPetsPage : ContentPage
{
    private readonly LocalDbService _dbService;
    public MyPetsPage(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => listView.ItemsSource = await _dbService.GetPets());
	}
}