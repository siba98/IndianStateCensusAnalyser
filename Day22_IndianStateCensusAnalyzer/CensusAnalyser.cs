using Day22_IndianStateCensusAnalyzer.DTO;
using System.Collections.Generic;

namespace Day22_IndianStateCensusAnalyzer
{
    public class CensusAnalyser
    {
        public static int a = 10;
        public enum Country
        {
            INDIA, US, BRAZIL
        }

        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeaders)
        {
            //CensusAnalyser obj = new CensusAnalyser();
            //Console.WriteLine(obj.a);
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
