using System;

namespace StoreDDD.DomainCore.UnitOfWork
{
    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        int Commit();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        void Rollback();
    }
}
