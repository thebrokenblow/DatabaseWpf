using DatabaseWpf.Core;
using DatabaseWpf.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DatabaseWpf.ViewModel;

public class UserViewModel : INotifyPropertyChanged
{
    private bool isUserBeingAdded;
    public bool IsUserBeingAdded
    {
        get => isUserBeingAdded;
        set
        {
            isUserBeingAdded = value;
            OnPropertyChanged();
        }
    }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Email { get; set; }

    public RelayCommand AddUserCommand { get; }

    public UserViewModel()
    {
        AddUserCommand = new RelayCommand(AddUserAsync, obj => true);
    }

    public async void AddUserAsync(object? obj)
    {
        IsUserBeingAdded = true;

        var user = new User()
        {
            Name = Name,
            Surname = Surname,
            Patronymic = Patronymic,
            Email = Email
        };

        using var db = new ApplicationContext();

        await Task.Delay(2000);
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();

        IsUserBeingAdded = false;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}