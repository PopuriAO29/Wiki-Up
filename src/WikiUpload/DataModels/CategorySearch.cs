﻿using System.Threading.Tasks;
using WikiUpload.Properties;

namespace WikiUpload
{
    public class CategorySearch : WikiSearch
    {
        private readonly IFileUploader _fileUploader;

        public CategorySearch(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
        }

        public override Task<SearchResponse> FetchData(string from)
        {
            return _fileUploader.FetchCategories(from);
        }

        public override string FullItemString(string item) => string.Format(Resources.CategoryTemplate, item);
    }
}
