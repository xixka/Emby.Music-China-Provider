using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Emby.MeiamSub.Thunder.Consts;
using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Configuration;
using MediaBrowser.Controller.Entities.Audio;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.IO;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Providers;
using MediaBrowser.Model.Serialization;
using MusicProvider.Models;

namespace MusicProvider
{
    public class MusicAlbumProvider : IRemoteMetadataProvider<MusicAlbum, AlbumInfo>, IHasOrder
    {
        public int Order => 0;
        
        private const string UA = "PostmanRuntime/7.28.4";
        
        public string Name => "Music-China";
        
        private readonly ILogger _logger;
        private readonly IJsonSerializer _json;
        private readonly IHttpClient _httpClient;
        private readonly IServerConfigurationManager _config;
        private readonly IFileSystem _fileSystem;
        
        /**
         * 识别调用这里
         */
        public Task<IEnumerable<RemoteSearchResult>> GetSearchResults(AlbumInfo searchInfo, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /**
         * 搜刮调用这里
         */
        public Task<MetadataResult<MusicAlbum>> GetMetadata(AlbumInfo info, CancellationToken cancellationToken)
        {
            // info.AlbumArtists
            throw new System.NotImplementedException();
        }

        /**
         * 根据专辑名字和歌手名字获取信息
         */
        public async Task<SearchAlbumJson> ByNameSearchAlbum(String Albumname,String MusicName)
        {
            String SearchKey = Albumname + " " + MusicName;
            _logger.Debug($"搜索专辑 --> {SearchKey}");
            SearchAlbumJson result ;
            var options = new HttpRequestOptions
            {
                Url =
                    $"http://music.163.com/api/search/get/web?csrf_token=hlpretag=&s={SearchKey}&type=10&offset=0&limit=20",
                UserAgent = UA,
                EnableHttpCompression = false,
                RequestHeaders = { { "X-Real-IP", Consts.RealIP } }
            };
            using (var json = await _httpClient.Get(options).ConfigureAwait(false))
            {
                using (var reader = new StreamReader(json))
                {
                    var jsonText = await reader.ReadToEndAsync().ConfigureAwait(false);
                    _logger.Debug($"读取到网易云返回的结果 --> {jsonText}");
                    result = _json.DeserializeFromString<SearchAlbumJson>(jsonText);
                }
            }
            if (result != null && result.result.albumCount != 0)
            {
                // 有结果返回进行处理
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task setup()
        {
            
        }

        /**
         * 暂时不提供专辑图片
         */
        public Task<HttpResponseInfo> GetImageResponse(string url, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        
    }
}