using I.MES.Tools;

namespace I.MES.GlobalCore
{
    /// <summary>
    /// 编译器
    /// </summary>
    public class Compiler
    {
        Serializer serial;

        public Compiler()
        {
            serial = new Serializer();
        }

        public object Compile(object data)
        {
            switch (BasicProperty.ClientInfo.TransferMethod)
            {
                case TransferType.Xml:
                    return CompileToXML(data);
                case TransferType.Json:
                    return CompileToJson(data);
                case TransferType.Bytes:
                    return CompileToBytes(data);
                default:
                    return CompileToXML(data);
            }
        }

        private byte[] CompileToBytes(object data)
        {
            return serial.ByteSerialize(data);
        }

        private string CompileToJson(object data)
        {
            return serial.JsonSerialize(data);
        }

        private string CompileToXML(object data)
        {
            string x = serial.XMLSerialize(data);
            return serial.XMLSerialize(data);
        }

    }
}
