using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Emby.MeiamSub.Thunder;
using Emby.MeiamSub.Thunder.Consts;
using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Configuration;
using MediaBrowser.Controller.Entities.Audio;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.IO;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Providers;
using MediaBrowser.Model.Serialization;
using MusicProvider.Models;

namespace MusicProvider
{
    /*
     * 艺术家搜刮器
     */
    public class MusicProvider : IRemoteMetadataProvider<MusicArtist, ArtistInfo>, IHasOrder
    {
        public int Order => 0;

        private const string UA = "PostmanRuntime/7.28.4";

        public string Name => "Music-China";


        private readonly ILogger _logger;
        private readonly IJsonSerializer _json;
        private readonly IHttpClient _httpClient;
        private readonly IServerConfigurationManager _config;
        private readonly IFileSystem _fileSystem;

        public MusicProvider(ILogger logger, IServerConfigurationManager config, IFileSystem fileSystem,
            IJsonSerializer jsonSerializer, IHttpClient httpClient)
        {
            _logger = logger;
            _json = jsonSerializer;
            _config = config;
            _httpClient = httpClient;
            _fileSystem = fileSystem;
        }

        public async Task<IEnumerable<RemoteSearchResult>> GetSearchResults(ArtistInfo searchInfo,
            CancellationToken cancellationToken)
        {
            _logger.Debug("触发GetSearchResults");
            var remoteSearchResults = new List<RemoteSearchResult>();
            var MusicName = GetMusicArtistName(searchInfo);
            _logger.Info($"搜索艺术家 --> {MusicName}");
            SearchJson result;
            var options = new HttpRequestOptions
            {
                Url =
                    $"http://music.163.com/api/search/get/web?csrf_token=hlpretag=&s={MusicName}&type=100&offset=0&limit=20",
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
                    result = _json.DeserializeFromString<SearchJson>(jsonText);
                }
            }

            if (result != null && result.result.artistCount != 0)
            {
                foreach (var resultArtist in result.result.artists)
                {
                    var n1 = new RemoteSearchResult();
                    n1.Name = resultArtist.name;
                    n1.ImageUrl = resultArtist.img1v1Url + "?param=300y300";
                    remoteSearchResults.Add(n1);
                }
            }

            return await Task.FromResult<IEnumerable<RemoteSearchResult>>(remoteSearchResults);
        }


        private static string GetMusicArtistName(ArtistInfo info)
        {
            return info.Name;
        }

        public async Task<MetadataResult<MusicArtist>> GetMetadata(ArtistInfo info, CancellationToken cancellationToken)
        {
            _logger.Debug("触发GetMetadata");
            // 1.获取名字
            var MusicName = GetMusicArtistName(info);
            _logger.Info($"搜刮艺术家 --> {MusicName}");
            var res = new MetadataResult<MusicArtist>();
            res.Item = new MusicArtist();
            res.HasMetadata = true;
            await FetchData(res.Item, MusicName).ConfigureAwait(false);
            return res;
        }

        protected async Task FetchData(MusicArtist item, string MusicName)
        {
            _logger.Debug($"获取到歌手姓名 --> {MusicName}");
            SearchJson result;
            var options = new HttpRequestOptions
            {
                Url =
                    $"http://music.163.com/api/search/get/web?csrf_token=hlpretag=&s={MusicName}&type=100&offset=0&limit=20",
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
                    result = _json.DeserializeFromString<SearchJson>(jsonText);
                }
            }

            if (result != null && result.result.artistCount != 0)
            {
                // 有结果返回进行处理
                _logger.Debug($"读取到网易云搜索到歌手数量为 --> {result.result.artistCount}");
                await ProcessArtistData(item, result.result.artists[0], MusicName).ConfigureAwait(false);
            }
        }


        private async Task ProcessArtistData(MusicArtist artist, ArtistsItem data, string MusicName)
        {
            ArtistDetailJson result = null;

            // 设置网易云id
            artist.ExternalId = data.id;


            // 获取歌手描述
            if (!((IList)artist.LockedFields).Contains(MetadataFields.Overview))
            {
                using (var json = await _httpClient.Get(new HttpRequestOptions
                       {
                           Url = $"https://music.163.com/api/artist/head/info/get?id={data.id}",
                           UserAgent = UA,
                           EnableHttpCompression = false,
                           RequestHeaders = { { "X-Real-IP", Consts.RealIP } }
                       }).ConfigureAwait(false))
                {
                    using (var reader = new StreamReader(json))
                    {
                        var jsonText = await reader.ReadToEndAsync().ConfigureAwait(false);
                        _logger.Debug($"网易云读取到歌手描述为 --> {jsonText}");
                        result = _json.DeserializeFromString<ArtistDetailJson>(jsonText);
                        artist.Overview = result.data.artist.briefDesc;
                    }
                }
            }

            // 设置图像url
            var url = result.data.artist.cover + "?param=300y300";
            _logger.Debug($"网易云歌手url --> {url}");
            if (!string.IsNullOrEmpty(data.id) && !string.IsNullOrEmpty(url))
            {
                ImageHelper.SaveImageInfo(_config.ApplicationPaths, _logger, _fileSystem, MusicName, url);
            }
        }


        public Task<HttpResponseInfo> GetImageResponse(string url, CancellationToken cancellationToken)
        {
            _logger.Debug("触发GetImageResponse");
            return _httpClient.GetResponse(new HttpRequestOptions
            {
                CancellationToken = cancellationToken,
                Url = url
            });
        }
    }
}