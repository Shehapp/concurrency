//https://leetcode.com/problems/web-crawler-multithreaded/description/
using System.Collections;
using System.Threading ;


// we can replace .join() with semaphores but ok computer ;

class Program
{
    static void Main(string[] args)
    {

        Solution s = new Solution();
        HtmlParser hp = new HtmlParser();
        IList<string> ans = s.Crawl("http://news.yahoo.com/news/topics/", hp);
        foreach (string ss in ans)
        {
            System.Console.WriteLine(ss);
        }

    }
}

class Solution
{
    // create hash map to store visited urls
    private HashSet<string> ans;
    private Semaphore sem;
    public Solution()
    {
        ans = new HashSet<string>();
        sem = new Semaphore(1);
    }

    public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
    {
        bool flag;
        sem.Wait();
        flag = ans.Contains(startUrl);
        if (!flag)
        {
            ans.Add(startUrl);
        }
        sem.Signal();
        if (flag) return null;

        List<String> res = htmlParser.getUrls(startUrl);
        foreach (string s in res)if(ma4i(startUrl,s))
        {
            Thread t = new Thread(() => Crawl(s, htmlParser));
            t.Start();
            t.Join();
        }
        return ans.ToList();
    }

    public bool ma4i(string startUrl, string s)
    {
        string tmp = s.Substring(s.IndexOf("//") + 2);
        try
        {
            tmp = tmp.Substring(0, tmp.IndexOf("/"));

        }
        catch (Exception e)
        { }
        string tmp2 = startUrl.Substring(startUrl.IndexOf("//") + 2);
        try
        {
            tmp2 = tmp2.Substring(0, tmp2.IndexOf("/"));
        }
        catch (Exception e)
        { }
        return tmp == tmp2;
    }

}

class HtmlParser
{
    // Return a list of all urls from a webpage of given url.
    // This is a blocking call, that means it will do HTTP request and return when this request is finished.
    private Dictionary<String,List<String> >okList;
    public HtmlParser()
    {
        okList = new Dictionary<string, List<string>>();
        okList["http://news.yahoo.com"] = new List<string>()
            { "http://news.yahoo.com/news/topics/", "http://news.yahoo.com/us" };
        okList["http://news.yahoo.com/news"] = new List<string>()
            { "http://news.yahoo.com/news/topics/", "http://news.google.com" };
        okList["http://news.yahoo.com/news/topics/"] = new List<string>()
            { "http://news.yahoo.com", "http://news.yahoo.com/news" };
        okList["http://news.google.com"] = new List<string>()
            { "http://news.yahoo.com/news/topics/", "http://news.yahoo.com/news" };
        okList["http://news.yahoo.com/us"] = new List<string>()
            { "http://news.yahoo.com"};

    }
    public List<String> getUrls(String url)
    {
        return okList[url];
    }
}

class Semaphore
{
    public int count ;
    public Semaphore()
    {
        count = 0 ;
    }
    public Semaphore(int InitialVal)
    {
        count = InitialVal ;
    }
    public void Wait()
    {
        lock(this)
        {
            count-- ;
            if (count < 0)
                Monitor.Wait(this,Timeout.Infinite) ;
        }
    }
    public void Signal()
    {
        lock(this)
        {
            count++ ;
            if (count <= 0)
                Monitor.Pulse (this) ;
        }
    }
}