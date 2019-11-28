using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_PageContent
{
    class Program
    {
        static void Main(string[] args)
        {
            RealWebServerClass PageService = new RealWebServerClass();
            CachedWebServerClass PageProxyServer = new CachedWebServerClass(PageService);
            YouTubeManager client = new YouTubeManager(PageProxyServer);
            client.ReactOnUserInput(21331);
            Console.WriteLine("###########################");
            client.ReactOnUserInput(21331 );
            Console.ReadKey();
        }
    }
    interface WebServer
    {
        string listBlogs();
        string getBlogInfo(int id);
        void downloadWebPage(int id);
    }
    class RealWebServerClass : WebServer
    {
        public int[] downloadArray;
        public RealWebServerClass ()
        {
            downloadArray = new int[100];
        }
        public bool checkerVideoExist( int id)
        {
            if( Array.IndexOf(downloadArray, id ) > -1)
                return true;
            return false;
        }
        public string listBlogs()
        {
            Console.WriteLine("Вывод списка статей с Web сервера");
            return "Список статей, взятых с Web сервера";
        }
        public string getBlogInfo (int id)
        {
            Console.WriteLine("Получение детальной информации о статье под id: {0}", id);
            return "Детальная информация статьи " + id;
        }
        public void downloadWebPage(int id)
        {
            Console.WriteLine("Скачивание страницы статьи блога под id: {0}", id);
            downloadArray[downloadArray.Length] = id;
        }
    }
    class CachedWebServerClass : WebServer
    {
        private RealWebServerClass service;
        private string listCache, videoCache;
        private bool needReset;

        public CachedWebServerClass (RealWebServerClass service)
        {
            this.service = service;
        }
        public string listBlogs()
        {
            if (listCache == null || needReset)
                listCache = service.listBlogs();
            return listCache;
        }
        public string getBlogInfo(int id)
        {
            if (videoCache == null || needReset)
                videoCache = service.getBlogInfo(id);
            return videoCache;
        }
        public void downloadWebPage(int id)
        {
            if (!service.checkerVideoExist(id) || needReset)
                service.downloadWebPage(id);
        }
    }
    class YouTubeManager
    {
        protected CachedWebServerClass service;

        public YouTubeManager(CachedWebServerClass service)
        {
            this.service = service;
        }
        public void RenderVideoPage(int id)
        {
            string info = service.getBlogInfo(id);
            Console.WriteLine(info);
        }
        public void RenderListPanel()
        {
            string list = service.listBlogs();
            Console.WriteLine(list);
        }
        public void ReactOnUserInput(int id)
        {
            RenderVideoPage(id);
            RenderListPanel();
        }
    }
}
