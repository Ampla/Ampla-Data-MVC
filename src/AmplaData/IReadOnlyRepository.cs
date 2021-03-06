﻿using System;
using System.Collections.Generic;
using AmplaData.Records;

namespace AmplaData
{
    /// <summary>
    /// Interface that provides read only access to the repository
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public interface IReadOnlyRepository<TModel> : IDisposable
    {
        /// <summary>
        /// Get all the models 
        /// </summary>
        /// <returns></returns>
        IList<TModel> GetAll();

        /// <summary>
        ///     Finds a model using the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel FindById(int id);

        /// <summary>
        /// Finds the record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AmplaRecord FindRecord(int id);

        /// <summary>
        ///     Find a list of models that match the specified filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        IList<TModel> FindByFilter(params FilterValue[] filters);

        /// <summary>
        /// Validates the interface to check for expected Ampla mapping.
        /// </summary>
        /// <param name="example">The example model</param>
        /// <returns></returns>
        IList<string> ValidateMapping(TModel example);
    }
}