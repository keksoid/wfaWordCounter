using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatistics.Interfaces
{
    /// <summary>
    /// Result of file analysis
    /// </summary>
    public enum AnalysisResult
    {
        /// <summary>
        /// Analysis complete and result statistics can be used on client
        /// </summary>
        Complete,

        /// <summary>
        /// Analysis canceled and result statistics(only than has been collected) can be used on client
        /// </summary>
        Canceled,

        /// <summary>
        /// File, provided for analysis not found. Empty statistics
        /// </summary>
        ErrorFileNotFound,

        /// <summary>
        /// File path, provided for analysis is empty or null. Empty statistics
        /// </summary>
        ErrorFileNameIsEmptyOrNull
    }
}
