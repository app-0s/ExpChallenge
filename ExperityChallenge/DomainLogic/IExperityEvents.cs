using ExperityChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperityChallenge.DomainLogic
{
    /// <summary>
    /// Interface of events which must be implemented by child method
    /// </summary>
    public interface IExperityEvents
    {
        /// <summary>
        /// Rereives string collection for numbers 1 - 100, with special strings created for multiples of 3, 5, and both 3 & 5
        /// </summary>
        /// <returns></returns>
        Task<IList<EventResultModel>> Register();
        /// <summary>
        /// builds string collection for numbers 1 - 100, with special strings created for multiples of 2, 7, and both 2 & 7
        /// </summary>
        /// <returns></returns>
        Task<IList<EventResultModel>> Diagnose();

    }
}
