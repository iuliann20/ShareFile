using System;

namespace ShareFile.TL.DTO
{
    public class SharedFileDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public DateTime? UploadDate { get; set; }
        public int UserId { get; set; }
    }
}
