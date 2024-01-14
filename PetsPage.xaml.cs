namespace DogSPA;

public partial class PetsPage : ContentPage
{
	private readonly LocalDbService _dbService;
	private int _editPetId;
	public PetsPage(LocalDbService dbService)
	{
		InitializeComponent();
		_dbService = dbService;
		Task.Run(async () => listView.ItemsSource = await _dbService.GetPets());
	}

	private async void saveButton_Clicked(object sender, EventArgs e)
	{
		if (_editPetId == 0)
		{
			//add pet
			await _dbService.CreatePet(new Pet
			{
				Name = nameEntryField.Text,
				Race = raceEntryField.Text,
				Size = sizeEntryField.Text,
				Birthday = birthdayEntryField.Date,
				Picture = pet_pictureEntryField.Text
			});
		}
		else
		{
			//update pet
			await _dbService.UpdatePet(new Pet
			{
				Id = _editPetId,
				Name = nameEntryField.Text,
				Race = raceEntryField.Text,
				Size = sizeEntryField.Text,
				Birthday = birthdayEntryField.Date,
				Picture = pet_pictureEntryField.Text
			});
			
			_editPetId = 0;
		}

		nameEntryField.Text = string.Empty;
		raceEntryField.Text = string.Empty;
		sizeEntryField.Text = string.Empty;
		birthdayEntryField.Date = DateTime.MinValue;
		pet_pictureEntryField.Text = string.Empty;

		listView.ItemsSource = await _dbService.GetPets();
	}

	private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var pet = (Pet)e.Item;
		var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

		switch (action)
		{
			case "Edit":

				_editPetId = pet.Id;
                nameEntryField.Text = pet.Name;
                raceEntryField.Text = pet.Race;
                sizeEntryField.Text = pet.Size;
                birthdayEntryField.Date = pet.Birthday;
                pet_pictureEntryField.Text = pet.Picture;

                break;
			case "Delete":

				await _dbService.DeletePet(pet);
				listView.ItemsSource = await _dbService.GetPets();

				break;
		}
	}
}
