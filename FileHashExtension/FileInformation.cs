using System;
using System.Collections.Generic;
using System.Text;

namespace FileHashExtension
{
    class FileInformation
    {
        public string Name { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public string Hash { get; set; } = string.Empty;

        public DateTime FileDate { get; set; }

        public Int64 FileSize { get; set; } = 0;
    }
}
