using System.Collections.Generic;

namespace MusicProvider.Models
{

    
    public class ArtistsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 周杰伦
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string picUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List <string > alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int albumSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int picId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string img1v1Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int img1v1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mvSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string followed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List <string > alia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string trans { get; set; }
    }
 
    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public int artistCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List <ArtistsItem > artists { get; set; }
    }
 
    public class SearchJson
    {
        /// <summary>
        /// 
        /// </summary>
        public Result result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
    }
}