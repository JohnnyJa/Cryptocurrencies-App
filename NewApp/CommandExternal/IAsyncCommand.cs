using System.Threading.Tasks;
using System.Windows.Input;

namespace NewApp.CommandExternal;

public interface IAsyncCommand : ICommand
{
    Task ExecuteAsync(object parameter);
}