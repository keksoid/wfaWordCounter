using FileStatistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStatistics.Impl
{
    /// <summary>
    /// Base class for all File Analyzers types
    /// </summary>
    /// <remarks>
    /// Provides async reading of specified file.
    /// All successors of this class should implement methods to provide their own statistics algorythms
    /// </remarks>
    internal abstract class FileAnalyzer : IFileAnalyzer
    {
        #region Private members
        private AnalysisStatus? InitProgress(IProgress<AnalysisStatus>? progress = default)
        {
            if (progress == null)
                return null;

            var fileInfo = new FileInfo(FullFilePath);

            var analisysStatus = new AnalysisStatus
            {
                //reporting start of analysis
                FileSize = fileInfo.Length,
                CompleteStatus = 0,                
                CurrentBytesInStep = 0,
                FullFilePath = fileInfo.FullName,
            };            

            progress?.Report(analisysStatus);

            return analisysStatus;
        }

        private void DoReportProgress(AnalysisStatus? analisysStatus, IProgress<AnalysisStatus>? progress = default)
        {
            if (analisysStatus == null)
                return;

            //every stepsize report progress
            analisysStatus.CurrentBytesInStep += 1;

            if (analisysStatus.CurrentBytesInStep == analisysStatus.StepSize)
            {
                analisysStatus.CompleteStatus += 1;
                progress?.Report(analisysStatus);

                analisysStatus.CurrentBytesInStep = 0;
            }
        }
        #endregion

        #region Protected members
        /// <summary>
        /// Allows successor to control the flow of file analysis
        /// </summary>
        protected enum ByteProcessingResult
        {
            Continue,
            Stop
        }

        /// <summary>
        /// Full path to file to work with
        /// </summary>
        protected string FullFilePath { get; }

        /// <summary>
        /// Creates specific IFileStatistics implementator
        /// </summary>
        /// <returns>IFileStatistics implementator that will be returned from Analyze() method</returns>        
        protected abstract IFileStatistics GetFileStatistics();

        /// <summary>
        /// Processing of each read byte
        /// </summary>
        /// <param name="readByte">Current byte</param>
        /// <returns>Decision to next action</returns>
        protected abstract ByteProcessingResult OnProcessNextByte(byte readByte);

        #endregion

        #region Public members   
        public FileAnalyzer(string fullFilePath)
        {
            this.FullFilePath = fullFilePath;
        }

        /// <summary>
        /// Base async implementation of file analization
        /// </summary>
        /// <param name="cancellation">Token to cancel current analysis</param>
        /// <param name="progress">Call back to report analysis progress to user</param>
        /// <returns>Result of analyzis</returns>
        /// <exception cref="ArgumentNullException">If CreateFileStatistics() doen't return FileStatistics successor</exception>
        public virtual async Task<IFileStatistics> AnalyzeAsync(CancellationToken cancellation = default, IProgress<AnalysisStatus>? progress = default)
        {
            //Analyze method should always return a value
            if (GetFileStatistics() is not FileStatistics stats)
                throw new MissingMethodException("Method CreateFileStatistics must return FileStatistics successor!");

            if (string.IsNullOrEmpty(FullFilePath))
            {
                stats.Summary.Append("File name is not provided!");
                stats.AnalysisResult = AnalysisResult.ErrorFileNameIsEmptyOrNull;
                return stats;
            }

            if (!File.Exists(FullFilePath))
            {
                stats.AnalysisResult = AnalysisResult.ErrorFileNotFound;
                stats.Summary.Append($"File {FullFilePath} doesn't exists!");
                return stats;
            }                        
            
            var analisysStatus = InitProgress(progress);  

            //open stream to file
            await using var sourceStream =
                new FileStream(
                    FullFilePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true
                );                        

            var buffer = new byte[0x1000];
            int numRead;            

            //async reading portion of bytes from file
            while ((numRead = await sourceStream.ReadAsync(buffer, cancellation)) != 0)
            {                
                cancellation.ThrowIfCancellationRequested();                

                //process each read byte 
                for (int i = 0; i < numRead; i++)
                {
                    //successor can stop the analysis
                    if (OnProcessNextByte(buffer[i]) == ByteProcessingResult.Stop)
                        return stats;

                    cancellation.ThrowIfCancellationRequested();

                    //on every byte analyze report progress
                    DoReportProgress(analisysStatus, progress);                    
                }
            }            

            return stats;
        }       
        #endregion
    }
}
