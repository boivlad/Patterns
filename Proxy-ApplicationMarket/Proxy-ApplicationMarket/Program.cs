using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_ApplicationMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            RealAppMarketClass AppMarket = new RealAppMarketClass();
            CachedAppMarketClass ProxyAppMarket = new CachedAppMarketClass(AppMarket);
            AppManager manager = new AppManager(ProxyAppMarket);
            manager.ReactOnUserInput(32);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");
            manager.ReactOnUserInput(32);
            Console.ReadKey();
        }
    }
    interface AppMarketStore
    {
        string listApplications();
        string getAppInfo(int id);
        void downloadApplication(int id);
    }
    class RealAppMarketClass : AppMarketStore
    {
        public int[] downloadArray;
        public RealAppMarketClass()
        {
            downloadArray = new int[100];
        }
        public bool checkerApplicationExist(int id)
        {
            if (Array.IndexOf(downloadArray, id) > -1)
                return true;
            return false;
        }
        public string listApplications()
        {
            Console.WriteLine("Вывод списка приложений");
            return "Список приложений, взятых с AppMarket";
        }
        public string getAppInfo(int id)
        {
            Console.WriteLine("Получение детальной информации о приложении с id: {0}", id);
            return "Детальная информация приложения " + id;
        }
        public void downloadApplication(int id)
        {
            Console.WriteLine("Скачивание приложения под id: {0}", id);
            downloadArray[downloadArray.Length] = id;
        }
    }
    class CachedAppMarketClass : AppMarketStore
    {
        private RealAppMarketClass service;
        private string listCache, appCache;
        private bool needReset;

        public CachedAppMarketClass(RealAppMarketClass service)
        {
            this.service = service;
        }
        public string listApplications()
        {
            if (listCache == null || needReset)
                listCache = service.listApplications();
            return listCache;
        }
        public string getAppInfo(int id)
        {
            if (appCache == null || needReset)
                appCache = service.getAppInfo(id);
            return appCache;
        }
        public void downloadApplication(int id)
        {
            if (!service.checkerApplicationExist(id) || needReset)
                service.downloadApplication(id);
        }
    }
    class AppManager
    {
        protected CachedAppMarketClass service;

        public AppManager(CachedAppMarketClass service)
        {
            this.service = service;
        }
        public void InstallApplication(int id)
        {
            string info = service.getAppInfo(id);
            Console.WriteLine(info);
        }
        public void RenderListPanel()
        {
            string list = service.listApplications();
            Console.WriteLine(list);
        }
        public void ReactOnUserInput(int id)
        {
            InstallApplication(id);
            RenderListPanel();
        }
    }
}
