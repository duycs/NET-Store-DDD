using System.Threading.Tasks;

namespace StoreDDD.DomainCore.Commands
{
    /// <summary>
    /// Interface IMediatorHandler
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Sends the specified command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        Task Send<T>(T command) where T : Command;
    }
}
