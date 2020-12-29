using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace I.MES.Tools
{
    public class DependSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property
        = new ConfigurationProperty(string.Empty, typeof(DependentCollection), null,
                                        ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public DependentCollection KeyValues
        {
            get
            {
                return (DependentCollection)base[s_property];
            }
        }
    }

    [ConfigurationCollection(typeof(DependentSetting))]
    public class DependentCollection : ConfigurationElementCollection        // 自定义一个集合
    {
        // 基本上，所有的方法都只要简单地调用基类的实现就可以了。
        public DependentCollection()
            : base(StringComparer.OrdinalIgnoreCase)    // 忽略大小写
        {
        }

        // 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
        new public DependentSetting this[string name]
        {
            get
            {
                try
                {
                    return (DependentSetting)base.BaseGet(name);
                }
                catch
                {
                    return null;
                }
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new DependentSetting();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DependentSetting)element).Interface;
        }

        // 说明：如果不需要在代码中修改集合，可以不实现Add, Clear, Remove
        public void Add(DependentSetting setting)
        {
            this.BaseAdd(setting);
        }
        public void Clear()
        {
            base.BaseClear();
        }
        public void Remove(string name)
        {
            base.BaseRemove(name);
        }
    }

    public class DependentSetting : ConfigurationElement    // 集合中的每个元素
    {
        [ConfigurationProperty("interface", IsRequired = true)]
        public string Interface
        {
            get { return this["interface"].ToString(); }
            set { this["interface"] = value; }
        }

        [ConfigurationProperty("impl", IsRequired = true)]
        public string Impl
        {
            get { return this["impl"].ToString(); }
            set { this["impl"] = value; }
        }
    }
}

public class DependentManage
{
    I.MES.Tools.DependentCollection dc;

    public DependentManage()
    {
        dc = ((I.MES.Tools.DependSection)ConfigurationManager.GetSection("dependent")).KeyValues;
    }

    public static DependentManage _current;
    public static DependentManage Current
    {
        get
        {
            if (_current == null)
            {
                _current = new DependentManage();
            }
            return _current;

        }
    }

    public object GetImplement(string interfaceName)
    {
        var setting = dc[interfaceName];
        if (setting != null)
        {
            try
            {

                string impl = setting.Impl;
                var rtn = Activator.CreateInstance(Type.GetType(impl));
                return rtn;
            }
            catch (Exception ex)
            {
                throw new MESException(5312, ex);
            }
        }
        return null;
    }

    public T GetImplement<T>()
    {
        return (T)this.GetImplement(typeof(T).AssemblyQualifiedName);
    }

    public object this[string interfaceName]
    {
        get
        {
            return GetImplement(interfaceName);
        }
    }

}
