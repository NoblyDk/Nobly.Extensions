using System;
using Hyland.Unity;

namespace Nobly.Extensions.OnBase.Document
{
    public static class DocumentExtensions
    {
        public static Keyword GetKeywordByKeywordTypeId(this Hyland.Unity.Document document, long keywordTypeId)
        {
            foreach (var documentKeywordRecord in document.KeywordRecords)
            {
                foreach (var keyword in documentKeywordRecord.Keywords)
                {
                    if (keyword.KeywordType.ID == keywordTypeId)
                    {
                        return keyword;
                    }
                }
            }
            return null;
        }
        public static Keyword GetKeywordByKeywordTypeId(this Hyland.Unity.Document document, params long[] keywordTypeIds)
        {
            foreach (var keywordTypeId in keywordTypeIds)
            {
                foreach (var documentKeywordRecord in document.KeywordRecords)
                {
                    foreach (var keyword in documentKeywordRecord.Keywords)
                    {
                        if (keyword.KeywordType.ID == keywordTypeId)
                        {
                            return keyword;
                        }
                    }
                }
            }
            return null;
        }
        public static string GetValueByKeywordTypeId(this Hyland.Unity.Document document, long keywordTypeId)
        {
            foreach (var documentKeywordRecord in document.KeywordRecords)
            {
                foreach (var keyword in documentKeywordRecord.Keywords)
                {
                    if (keyword.KeywordType.ID == keywordTypeId)
                    {
                        return keyword.AlphaNumericValue;
                    }
                }
            }
            return null;
        }
        public static string GetValueByKeywordTypeId(this Hyland.Unity.Document document, params long[] keywordTypeIds)
        {
            foreach (var keywordTypeId in keywordTypeIds)
            {
                foreach (var documentKeywordRecord in document.KeywordRecords)
                {
                    foreach (var keyword in documentKeywordRecord.Keywords)
                    {
                        if (keyword.KeywordType.ID == keywordTypeId)
                        {
                            return keyword.AlphaNumericValue;
                        }
                    }
                }
            }
            return null;
        }
    }
}
