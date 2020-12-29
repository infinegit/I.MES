using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.Threading;

/// <summary>
/// 单个用户的数据存储库
/// </summary>
public class Persistence : IDisposable
{
    private Hashtable kv;

    public Persistence()
    {
        kv = new Hashtable();
    }

    /// <summary>
    /// 当前用户的数据存储库
    /// </summary>
    public static Persistence Current
    {
        get
        {
            return PersistenceStore.Current.StoreValue;
        }
    }

    /// <summary>
    /// 新增数据存储
    /// </summary>
    /// <param name="key">数据键值</param>
    /// <param name="value">数据</param>
    public void Add(string key, object value)
    {
        this.kv.Add(key, new PersistenceItem()
        {
            Key = key,
            Value = value,
            RefreshTime = DateTime.Now,
            IsLongTerm = true
        });
    }

    /// <summary>
    /// 新增数据存储
    /// </summary>
    /// <param name="key">数据键值</param>
    /// <param name="value">数据</param>
    /// <param name="expires">有效期（秒）</param>
    public void Add(string key, object value, int expires)
    {
        this.kv.Add(key, new PersistenceItem()
        {
            Key = key,
            Value = value,
            RefreshTime = DateTime.Now,
            TimeOut = expires
        });
    }

    /// <summary>
    /// 是否包含键值
    /// </summary>
    /// <param name="key">键值</param>
    /// <returns></returns>
    public bool Contains(string key)
    {
        return this.kv.Contains(key);
    }

    public object this[string key]
    {
        get
        {
            var item = (PersistenceItem)(this.kv[key]);
            if (item == null)
            {
                return null;
            }
            item.RefreshTime = DateTime.Now;
            return item.Value;
        }
        set
        {
            if (this.kv[key] == null)
            {
                this.Add(key, value);
            }
            else
            {
                var item = (PersistenceItem)(this.kv[key]);
                item.Value = value;
                item.RefreshTime = DateTime.Now;
            }
        }
    }

    /// <summary>
    /// 内存清整
    /// </summary>
    public void Arrange()
    {

        string[] keys = new string[kv.Keys.Count];
        kv.Keys.CopyTo(keys, 0);
        foreach (var key in keys)
        {
            var item = (PersistenceItem)kv[key];
            if (item.IsAlive == false)
            {
                kv.Remove(key);
            }
        }
    }

    #region IDisposable 成员

    public void Dispose()
    {
        this.kv = null;
    }

    #endregion

}

/// <summary>
/// 整个应用程序的数据存储库
/// </summary>
public class PersistenceStore
{
    private PersistenceStore()
    {
        Thread td = new Thread(Arrange);
        td.IsBackground = true;
        td.Start();
    }

    private static PersistenceStore _instence;
    private static object locker=new object();

    //整个应用程序的数据存储库
    public static PersistenceStore Current
    {
        get
        {
            if (_instence != null)
            {
                return _instence;
            }

            lock (locker)
            {
                if (_instence == null)
                {
                    _instence = new PersistenceStore();
                }
            return _instence;
        }
    }
    }

    private Hashtable store = new Hashtable();
    private Hashtable codeList = new Hashtable();
    public string PersistenceCode
    {
        private get
        {
            var currentID = Thread.CurrentThread.ManagedThreadId;
            foreach (var key in codeList)
            {
                var item = (System.Collections.DictionaryEntry)key;
                var tdID = item.Value;
                if (((int)tdID) == currentID)
                {
                    return (string)item.Key;
                }
            }
            return "";
        }
        set
        {
            if (codeList[value] != null)
            {
                codeList[value] = Thread.CurrentThread.ManagedThreadId;
                if (store[value] != null)
                {
                ((PersistenceItem)store[value]).RefreshTime = DateTime.Now;
            }
            }
            else
            {
                codeList.Add(value, Thread.CurrentThread.ManagedThreadId);
            }
        }
    }

    /// <summary>
    /// 获取当前用户的数据存储库
    /// </summary>
    internal Persistence StoreValue
    {
        get
        {
            if (!store.ContainsKey(PersistenceCode))
            {
                store[PersistenceCode] = new PersistenceItem()
                {
                    Key = PersistenceCode,
                    Value = new Persistence(),
                    RefreshTime = DateTime.Now,
                    TimeOut = 300
                };
            }

            var item = (PersistenceItem)store[PersistenceCode];
            item.RefreshTime = DateTime.Now;

            return (Persistence)((item).Value);
        }
    }

    /// <summary>
    /// 整理数据（减少内存的无端消耗）
    /// </summary>
    private void Arrange()
    {
        while (true)
        {
            string[] keys = new string[store.Keys.Count];
            store.Keys.CopyTo(keys, 0);
            foreach (var key in keys)
            {
                var item = (PersistenceItem)store[key];
                if (item.IsAlive == false)
                {
                    codeList.Remove(key);
                    store.Remove(key);
                }
                else
                {
                    Persistence p = (Persistence)item.Value;
                    p.Arrange();
                }
            }

            Thread.Sleep(2000);

        }
    }

}

internal class PersistenceItem
{
    public string Key { get; set; }
    public object Value { get; set; }
    public DateTime RefreshTime { get; set; }
    public int TimeOut { get; set; }
    public bool IsLongTerm { get; set; }
    public bool IsAlive
    {
        get
        {
            return IsLongTerm || DateTime.Now <= this.RefreshTime.AddSeconds(this.TimeOut);
        }
    }

}

