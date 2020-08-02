using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsVisionClient.DocsVisionClasses
{
    /// <summary>
    /// Класс вложений писем
    /// </summary>
    class Attachments
    {
        public int IDAttachment { get; set; }
        public int IDLetterAttachment { get; set; }
        public byte[] Attachment { get; set; }
    }
}
