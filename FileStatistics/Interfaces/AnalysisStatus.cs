using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatistics.Interfaces
{
    /// <summary>
    /// Class represents progress status of current analysis
    /// </summary>
    public class AnalysisStatus
    {
        /// <summary>
        /// Complete status in percents
        /// </summary>
        public int CompleteStatus { get; set; }

        /// <summary>
        /// File size in bytes
        /// </summary>
        public long FileSize {get; set; }        

        /// <summary>
        /// Number of bytes processed in current step
        /// </summary>
        public long CurrentBytesInStep { get; set; }

        /// <summary>
        /// Number of bytes in one full step
        /// </summary>
        public long StepSize => FileSize/StepsCount;

        /// <summary>
        /// All step count
        /// </summary>
        public readonly int StepsCount = 100;
    }
}
