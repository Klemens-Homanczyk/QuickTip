using linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace json
{
    internal class JsonTool
    {
        //step 1 open file and get json as String
        internal static string GetTextFromFile(string filePath)
        {
            string? text = null;

            using (StreamReader streamReader = File.OpenText(filePath))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }

        //step 2 get JsonDocument from json String
        internal static JsonDocument GetJsonDocumentFromString(string stringJson)
        {
            return JsonDocument.Parse(stringJson);
        }

        //step 3 combine step 1 and 2 into single step
        //get JsonDocument from file on disk
        internal static JsonDocument GetJsonDocumentFromFile(string filePath)
        {
            return GetJsonDocumentFromString(GetTextFromFile(filePath));
        }

        //step 4 deserialize JsonDocument into object of class ExampleDto
        internal static ExampleDto GetExampleDtoFromJsonDocument(JsonDocument jsonDocument)
        {
            ExampleDto receiptDocument = null;

            receiptDocument = JsonSerializer.Deserialize<ExampleDto>(jsonDocument);

            return receiptDocument;
        }

        //step 4 variant 1 deserialize json String into object of class ExampleDto 
        internal static ExampleDto GetExampleDtoFromJsonString(string stringJson)
        {
            ExampleDto receiptDocument = null;

            receiptDocument = GetExampleDtoFromJsonDocument(GetJsonDocumentFromString(stringJson));

            return receiptDocument;
        }

        //step 4 variant 2 deserialize file on disk into object of class ExampleDto 
        internal static ExampleDto GetExamoleDtoFromFile(string filePath)
        {
            ExampleDto receiptDocument = null;

            receiptDocument = GetExampleDtoFromJsonDocument(GetJsonDocumentFromFile(filePath));

            return receiptDocument;
        }

    }
}
