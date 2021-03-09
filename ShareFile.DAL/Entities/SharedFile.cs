using System;
using System.ComponentModel.DataAnnotations;

namespace ShareFile.DAL.Entities
{
    public class SharedFile
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}
