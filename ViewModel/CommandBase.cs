using System.ComponentModel;
using System.Windows.Input;

namespace ViewModel;

public sealed class NotifyTaskCompletion<TResult> : INotifyPropertyChanged
{
    public NotifyTaskCompletion(Task<TResult> task)
    {
        Task = task;
        if (!task.IsCompleted)
            TaskCompletion = WatchTaskAsync(task);
    }
    public Task TaskCompletion { get; private set; }

    private async Task WatchTaskAsync(Task task)
    {
        try
        {
            await task;
        }
        catch
        {
        }

        var propertyChanged = PropertyChanged;
        if (propertyChanged == null)
            return;
        propertyChanged(this, new PropertyChangedEventArgs("Status"));
        propertyChanged(this, new PropertyChangedEventArgs("IsCompleted"));
        propertyChanged(this, new PropertyChangedEventArgs("IsNotCompleted"));
        if (task.IsCanceled)
        {
            propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
        }
        else if (task.IsFaulted)
        {
            propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
            propertyChanged(this, new PropertyChangedEventArgs("Exception"));
            propertyChanged(this,
                new PropertyChangedEventArgs("InnerException"));
            propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
        }
        else
        {
            propertyChanged(this,
                new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
            propertyChanged(this, new PropertyChangedEventArgs("Result"));
        }
    }

    public Task<TResult> Task { get; private set; }

    public TResult Result
    {
        get { return (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult); }
    }

    public TaskStatus Status
    {
        get { return Task.Status; }
    }

    public bool IsCompleted
    {
        get { return Task.IsCompleted; }
    }

    public bool IsNotCompleted
    {
        get { return !Task.IsCompleted; }
    }

    public bool IsSuccessfullyCompleted
    {
        get
        {
            return Task.Status ==
                   TaskStatus.RanToCompletion;
        }
    }

    public bool IsCanceled
    {
        get { return Task.IsCanceled; }
    }

    public bool IsFaulted
    {
        get { return Task.IsFaulted; }
    }

    public AggregateException Exception
    {
        get { return Task.Exception; }
    }

    public Exception InnerException
    {
        get { return (Exception == null) ? null : Exception.InnerException; }
    }

    public string ErrorMessage
    {
        get { return (InnerException == null) ? null : InnerException.Message; }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}

public class CommandBase : ICommand
{
    private Action<object> execute;
    private Func<object, bool> canExecute;

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public CommandBase(Action<object> execute, Func<object, bool> canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return this.canExecute == null || this.canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        this.execute(parameter);
    }
}

public interface IAsyncCommand : ICommand
{
    Task ExecuteAsync(object parameter);
}

public abstract class AsyncCommandBase : IAsyncCommand
{
    public abstract bool CanExecute(object parameter);
    public abstract Task ExecuteAsync(object parameter);
    public async void Execute(object parameter)
    {
        await ExecuteAsync(parameter);
    }
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    protected void RaiseCanExecuteChanged()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}

public class AsyncCommand<TResult> : AsyncCommandBase
{
    private readonly Func<Task<TResult>> _command;
    private NotifyTaskCompletion<TResult> _execution;
    public AsyncCommand(Func<Task<TResult>> command)
    {
        _command = command;
    }
    public override bool CanExecute(object parameter)
    {
        return true;
    }
    public override Task ExecuteAsync(object parameter)
    {
        Execution = new NotifyTaskCompletion<TResult>(_command());
        return Execution.TaskCompletion;
    }
    // Генерируем PropertyChanged
    public NotifyTaskCompletion<TResult> Execution { get; private set; }
}