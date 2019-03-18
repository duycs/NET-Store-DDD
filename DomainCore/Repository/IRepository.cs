using System;
using System.Collections.Generic;
using StoreDDD.DomainCore.Models;
using StoreDDD.DomainCore.Specification;

namespace StoreDDD.DomainCore.Repository
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : Entity 
    {
        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T FindById(Guid id);

        /// <summary>
        /// Finds the single by spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>T.</returns>
        T FindSingleBySpec(ISpecification<T> spec);

        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> Find();

        /// <summary>
        /// Finds the specified spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> Find(ISpecification<T> spec);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        T Add(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
    }
}