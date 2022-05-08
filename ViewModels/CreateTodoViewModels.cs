using Flunt.Notifications;
using Flunt.Validations;
using minimalAPI.Models;

namespace minimalAPI.ViewModels;

public class CreateTodoViewModels : Notifiable<Notification>
{
    public string Title { get; set; }

    public Todo MapTo()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNull(Title, "Title")
            .IsGreaterThan(Title, 5, "O titulo deve ter mais de 5 caracteres.");

        AddNotifications(contract);

        return new Todo(Guid.NewGuid(), Title, false);
    }
}