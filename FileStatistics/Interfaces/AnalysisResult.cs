using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatistics.Interfaces
{
    public enum AnalysisResult
    {
        Complete,
        Canceled,
        ErrorFileNotFound,
        ErrorFileNameIsEmptyOrNull
    }
}
