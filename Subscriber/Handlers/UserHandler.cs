using Models;

namespace Subscriber
{
    public class UserHandler : IHandlerBase<User>
    {
        public Task HandleAsync(User message)
        {
            Console.WriteLine(message.ToString());
            Console.WriteLine(message.GetType());
            Console.WriteLine("Successs");
            return Task.CompletedTask;
        }
    }
}