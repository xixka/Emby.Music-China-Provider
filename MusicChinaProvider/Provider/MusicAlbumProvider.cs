using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Entities.Audio;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Providers;

namespace MusicProvider
{
    public class MusicAlbumProvider : IRemoteMetadataProvider<MusicAlbum, AlbumInfo>, IHasOrder
    {
        public int Order => 0;
        
        private const string UA = "PostmanRuntime/7.28.4";
        
        public string Name => "Music-China";
        
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
            throw new System.NotImplementedException();
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