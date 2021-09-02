using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Configuration;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Audio;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Configuration;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.IO;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Providers;
using MediaBrowser.Model.Serialization;

namespace MusicProvider
{
    public class MusicImageProvider: IRemoteImageProvider, IHasOrder
    {
        public string Name => "Music-China";
        public int Order => 0;
        
        
        private readonly ILogger _logger;
        private readonly IJsonSerializer _json;
        private readonly IHttpClient _httpClient;
        private readonly IServerConfigurationManager _config;
        private readonly IFileSystem _fileSystem;
        public MusicImageProvider( ILogger logger,IServerConfigurationManager config, IFileSystem fileSystem, IJsonSerializer jsonSerializer,IHttpClient httpClient)
        {
            _logger = logger;
            _json = jsonSerializer;
            _config = config;
            _httpClient = httpClient;
            _fileSystem = fileSystem;
        }


        public bool Supports(BaseItem item)
        {
            return  item is MusicArtist;
            // return item is MusicAlbum || item is MusicArtist;
        }

        public IEnumerable<ImageType> GetSupportedImages(BaseItem item)
        {
            return new List<ImageType>
            {
                ImageType.Primary
            };
        }

        public async Task<IEnumerable<RemoteImageInfo>> GetImages(BaseItem item, LibraryOptions libraryOptions, CancellationToken cancellationToken)
        {
            var list = new List<RemoteImageInfo>();
            RemoteImageInfo info = new RemoteImageInfo();
            var musicId = item is MusicAlbum ?
                item.GetProviderId(MetadataProviders.MusicBrainzAlbum) :
                item.Name;
            if (!string.IsNullOrEmpty(musicId))
            {
                var cachePath = Path.Combine(_config.ApplicationPaths.CachePath, "Music-China", musicId, "image.txt");
                // 读取到的图片地址
                var parts = (await _fileSystem.ReadAllTextAsync(cachePath).ConfigureAwait(false));
                _logger.Debug($"读取歌手图片地址为 --> {parts}");
                info.ProviderName = item.Name;
                info.Url = parts;
                info.Type = ImageType.Primary;
            }
            list.Add(info);
            return list;
        }
        

        public Task<HttpResponseInfo> GetImageResponse(string url, CancellationToken cancellationToken)
        {
            return _httpClient.GetResponse(new HttpRequestOptions
            {
                CancellationToken = cancellationToken,
                Url = url
            });
        }
        
    }
}