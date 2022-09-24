using System;
namespace BookmarkManager.Models
{
    public class Bookmark
    {
        public int ID {get; set;}
        public string? BookmarkName {get; set;}
        public string URL {get; set;}
        public int FolderId {get; set;}
        public DateTime CreationDate{get; set;}
        public DateTime UpdatedAt{get; set;}
    }

    public class Folder
    {
        public int Id{get; set;}

        public string folderName {get; set;}
        public string? description {get; set;}
        public DateTimeKind CreationDate{get; set;}
        public DateTimeKind UpdatedAt{get; set;}
    }
}