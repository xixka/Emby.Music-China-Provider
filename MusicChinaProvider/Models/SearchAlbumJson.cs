using System.Collections.Generic;

public class Artist
{
    /// <summary>
    /// 周杰伦
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int picId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int img1v1Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string briefDesc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string picUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string img1v1Url { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int albumSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <string > @alias { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string trans { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int musicSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string picId_str { get; set; }
}

public class AlbumArtistsItem
{
    /// <summary>
    /// 周杰伦
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int picId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int img1v1Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string briefDesc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string picUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string img1v1Url { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int albumSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <string > @alias { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string trans { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int musicSize { get; set; }
}

public class AlbumsItem
{
    /// <summary>
    /// 说好不哭
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string idStr { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int size { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int picId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string blurPicUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int companyId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int pic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string picUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int publishTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string description { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string tags { get; set; }
    /// <summary>
    /// 杰威尔
    /// </summary>
    public string company { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string briefDesc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Artist artist { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <string > songs { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <string > @alias { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int copyrightId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string commentThreadId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <AlbumArtistsItem > artists { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string picId_str { get; set; }
}

public class AlbumResult
{
    /// <summary>
    /// 
    /// </summary>
    public List <AlbumsItem > albums { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int albumCount { get; set; }
}

public class SearchAlbumJson
{
    /// <summary>
    /// 
    /// </summary>
    public AlbumResult result { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int code { get; set; }
}
