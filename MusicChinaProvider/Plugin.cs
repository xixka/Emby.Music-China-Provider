using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Drawing;
using System;
using System.IO;
using MediaBrowser.Model.Logging;

namespace Emby.MeiamSub.Thunder
{

    /// <summary>
    /// 插件入口
    /// </summary>
    public class Plugin : BasePlugin, IHasThumbImage
    {
        /// <summary>
        /// 插件ID  
        /// </summary>
        public override Guid Id => new Guid("D62D436F-E3C1-4F87-B73F-7EE13F3A5447");
        
        public static ILogger Logger { get; set; }

        /// <summary>
        /// 插件名称
        /// </summary>
        public override string Name => "Music-China";

        /// <summary>
        /// 插件描述
        /// </summary>
        public override string Description => "Chinese music";

        /// <summary>
        /// 缩略图格式化类型
        /// </summary>
        public ImageFormat ThumbImageFormat => ImageFormat.Gif;

        /// <summary>
        /// 缩略图资源文件
        /// </summary>
        /// <returns></returns>
        public Stream GetThumbImage()
        {
            var type = GetType();
            return type.Assembly.GetManifestResourceStream(type.Namespace + ".Thumb.png");
        }
    }
}
