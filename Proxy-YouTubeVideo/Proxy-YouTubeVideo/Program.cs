using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_YouTubeVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            ThirdPartyYoutubeClass youtubeService = new ThirdPartyYoutubeClass();
            CachedYoutubeClass youtubeProxy = new CachedYoutubeClass(youtubeService);
            YouTubeManager client = new YouTubeManager(youtubeProxy);

            Console.WriteLine("Имитация нажатия кнопки загрузки и воспроизведения видео с YouTube(Первое открытие)");
            client.ReactOnUserInput(2);
            Console.WriteLine("///////////////////");
            Console.WriteLine("Имитация нажатия кнопки загрузки и воспроизведения видео с YouTube(Повторное открытие)");
            client.ReactOnUserInput(2);
            Console.WriteLine("///////////////////");
            Console.WriteLine("Имитация нажатия кнопки загрузки и воспроизведения видео с YouTube(Повторное открытие)");
            client.ReactOnUserInput(2);

            Console.ReadKey();
        }
    }
    interface ThirdPartyYoutubeLib
    {
        string listVideos();
        string getVideoInfo(int id);
        void downloadVideo(int id);
    }
    class ThirdPartyYoutubeClass : ThirdPartyYoutubeLib
    {
        public int[] downloadArray;
        public ThirdPartyYoutubeClass ()
        {
            downloadArray = new int[100];
        }
        public bool checkerVideoExist( int id)
        {
            if( Array.IndexOf(downloadArray, id ) > -1)
                return true;
            return false;
        }
        public string listVideos()
        {
            Console.WriteLine("Вывод списка видео с помощью API YouTube");
            return "Список видео, взятых с API YouTube";
        }
        public string getVideoInfo (int id)
        {
            Console.WriteLine("Получение детальной информации о видиоролике под id: {0}", id);
            return "Детальная информация видео " + id;
        }
        public void downloadVideo(int id)
        {
            Console.WriteLine("Скачивание видео под id: {0}", id);
            downloadArray[downloadArray.Length] = id;
        }
    }
    class CachedYoutubeClass : ThirdPartyYoutubeLib
    {
        private ThirdPartyYoutubeClass service;
        private string listCache, videoCache;
        private bool needReset;

        public CachedYoutubeClass (ThirdPartyYoutubeClass service)
        {
            this.service = service;
        }
        public string listVideos()
        {
            if (listCache == null || needReset)
                listCache = service.listVideos();
            return listCache;
        }
        public string getVideoInfo(int id)
        {
            if (videoCache == null || needReset)
                videoCache = service.getVideoInfo(id);
            return videoCache;
        }
        public void downloadVideo(int id)
        {
            if (!service.checkerVideoExist(id) || needReset)
                service.downloadVideo(id);
        }
    }
    class YouTubeManager
    {
        protected CachedYoutubeClass service;

        public YouTubeManager(CachedYoutubeClass service)
        {
            this.service = service;
        }
        public void RenderVideoPage(int id)
        {
            string info = service.getVideoInfo(id);
            Console.WriteLine(info);
        }
        public void RenderListPanel()
        {
            string list = service.listVideos();
            Console.WriteLine(list);
        }
        public void ReactOnUserInput(int id)
        {
            RenderVideoPage(id);
            RenderListPanel();
        }
    }
}
