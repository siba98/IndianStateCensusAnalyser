using Day22_IndianStateCensusAnalyzer;
using Day22_IndianStateCensusAnalyzer.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static Day22_IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {

        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        
        static string indianStateCensusFilePath = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\IndiaStateCode.csv";
        
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";

        static string wrongIndianStateCensusFilePath = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData1.csv"; //giving wrong input as WrongIndiaStateCensusData1.csv is not present in our file 
        static string wrongIndianStateCodeFilePath = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode1.csv"; //giving wrong input as WrongIndiaStateCensusData1.csv is not present in our file 
        
        static string wrongIndianStateCensusFileType = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.txt"; //require csv file but given txt (file type error)
        static string wrongIndianStateCodeFileType = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\IndiaStateCode.txt"; //require csv file but given txt (file type error)
        
        static string delimiterIndianCensusFilePath = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\gyans\source\repos\Day22_IndianStateCensusAnalyzer\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
        //US Census FilePath
        //static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        //static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
        //static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
        //static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
        //static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
        //static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }


        /// <summary>
        /// TC 1.1 --> Given the indian census data file when readed should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }



        /// <summary>
        /// TC 1.2 --> Given the wrong indian census data file when readed should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }



        ///
        /// <summary>
        /// TC 1.3 --> Given the State Census CSV File when correct but type incorrect Returns a custom Exception (Passing correct File Path but file type should be incorrect)
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }



        /// <summary>
        /// TC 1.4 --> Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenIndianCensusDatafile_WhenDelimeterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }



        /// <summary>
        /// TC 1.5 --> Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenIndianCensusDatafile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA,  indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }      
    }
}