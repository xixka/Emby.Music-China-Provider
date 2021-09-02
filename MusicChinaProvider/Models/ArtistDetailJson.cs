using System.Collections.Generic;

namespace MusicProvider.Models
{
        public class Rank
    {
        /// <summary>
        /// 
        /// </summary>
        public int rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }
     
    public class Artist
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 周杰伦
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List <string > transNames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List <string > identities { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string identifyTag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string briefDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Rank rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int albumSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int musicSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mvSize { get; set; }
    }
     
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public int videoCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Artist artist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string blacklist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showPriMsg { get; set; }
    }
     
    public class ArtistDetailJson
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }
        
}