using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace I.MES.Tools
{
    public class CustomSection : ConfigurationSection    // 所有配置节点都要选择这个基类
    {
        private static readonly ConfigurationProperty s_property 
            = new ConfigurationProperty(string.Empty, typeof(TheKeyValueCollection), null,
                                                ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public TheKeyValueCollection KeyValues
        {
            get
            {
                return (TheKeyValueCollection)base[s_property];
            }
        }
    }

    [ConfigurationCollection(typeof(TheKeyValue))]
    public class TheKeyValueCollection : ConfigurationElementCollection        // 自定义一个集合
    {
        public TheKeyValueCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        { }
        new public TheKeyValue this[string name]
        {
            get
            {
                return (TheKeyValue)base.BaseGet(name);
            }
        }
        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new TheKeyValue();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TheKeyValue)element).Key;
        }
        //修改配置文件
        public void Add(TheKeyValue tkv)
        {
            this.BaseAdd(tkv);
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

    public class TheKeyValue : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return this["key"].ToString(); }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return this["value"].ToString(); }
            set { this["value"] = value; }
        }
    }
}

