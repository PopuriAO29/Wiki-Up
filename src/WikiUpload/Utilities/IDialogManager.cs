﻿using System;
using System.Collections.Generic;

namespace WikiUpload
{
    public interface IDialogManager
    {
        bool AddFilesDialog(string[] permittedExtensions, string imageExtensions, out IList<string> fileNames);
        bool ConfirmInsecureLoginDialog();
        void ErrorMessage(string message);
        void ErrorMessage(string message, Exception ex);
        bool ErrorMessage(string message, string subMessage, bool hasCancelButton = false);
        bool LoadContentDialog(out string fileName);
        bool LoadUploadListDialog(out string fileName);
        bool SaveContentDialog(out string fileName);
        bool SaveUploadListDialog(out string fileName);
        bool AddFolderDialog(out string folder);
        bool AddFolderOptionsDialog(
            string folderPath,
            out bool includeSubfolders,
            out IncludeFiles includeFiles,
            out string extension);
    }
}