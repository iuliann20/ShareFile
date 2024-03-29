﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareFile.DAL.Entities
{
    public class SharedFile
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public DateTime? UploadDate { get; set; }
        [ForeignKey("SharedFileUser")]
        public int UserId { get; set; }
        public SharedFileUser SharedFileUser { get; set; }
    }
}
