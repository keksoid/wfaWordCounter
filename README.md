wfaWordCounter project

Requirements: .Net 6.0 framework, C# 10.0, xUnit

Main solution: wfaWordCounter.sln

wfaWordCounter.csproj - winForms main app 

FileStatistics.csproj - library with FileStatistics analyzers

Usage: 
	API folder - factories for creating IFileAnalyzers for perfoming different analysis
	Interfaces folder - all common interfaces for all public APIs
	Implementation folder - internal implementation of the library capabilities

	IFileAnalyzerFactory - main interface for creating specific IFileAnalyzer
	IFileAnalyzer - main interface for objects, perfoming file analysis

	FileAnalyzer - base abstract class, which provides asynchronous scaning of the file and 
	successors of the class can implement their own logic for calculating statistics over contents of the file

	AnsiFileWordCountAnalyzer - collects all unique words in ansi encoded text files

	IFileStatistics - base interface for result of IFileAnalyzer work
	IAnsiFileWordCountStatistics - interface provides results of AnsiFileWordCountAnalyzer analyzer

FileStatisticsUnitTests - Unit tests for FileStatistics.csproj(xUnit test framework)