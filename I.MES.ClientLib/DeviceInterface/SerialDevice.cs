using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace DI
{
    /// <summary>
    /// 串口设备通讯
    /// </summary>
    public class SerialDevice : IProtocol<byte>,IProtocol<string>
    {
        public event DataArrivedEvent<byte> DataArrived;

        private SerialPort sp;

        #region 实例化

        /// <summary>
        /// 串口设备通讯
        /// </summary>
        public SerialDevice()
        {
            sp = new SerialPort();
            //sp.DataReceived += sp_DataReceived;
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var rtn = this.Read();
                DataArrived(rtn);
            }
            catch
            { }
        }

        /// <summary>
        /// 串口设备通讯
        /// </summary>
        /// <param name="portName">串口名称</param>
        public SerialDevice(string portName)
        {
            sp = new SerialPort(portName);
            //sp.DataReceived += sp_DataReceived;
        }

        /// <summary>
        /// 串口设备通讯
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        public SerialDevice(string portName, int baudRate)
        {
            sp = new SerialPort(portName, baudRate);
            //sp.DataReceived += sp_DataReceived;
        }

        /// <summary>
        /// 串口设备通讯
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        public SerialDevice(string portName, int baudRate, Parity parity)
        {
            sp = new SerialPort(portName, baudRate, parity);
            //sp.DataReceived += sp_DataReceived;
        }
        /// <summary>
        /// 串口设备通讯
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        public SerialDevice(string portName, string baudRate, string parity)
        {
            sp = new SerialPort(portName, Convert.ToInt32(baudRate), getParityFromString(parity));
            //sp.DataReceived += sp_DataReceived;
        }
        /// <summary>
        /// 串口设备通讯
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">数据位值</param>
        public SerialDevice(string portName, int baudRate, Parity parity, int dataBits)
        {
            sp = new SerialPort(portName, baudRate, parity, dataBits);
            //sp.DataReceived += sp_DataReceived;
        }
        /// <summary>
        /// 串口设备通讯
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">数据位值</param>
        public SerialDevice(string portName, string baudRate, string parity, string dataBits)
        {
            sp = new SerialPort(portName, Convert.ToInt32(baudRate), getParityFromString(parity), Convert.ToInt32(dataBits));
            //sp.DataReceived += sp_DataReceived;
        }
        /// <summary>
        /// 串口设备通讯
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">数据位值</param>
        /// <param name="stopBits">停止位数</param>
        public SerialDevice(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            sp = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            //sp.DataReceived += sp_DataReceived;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">数据位值</param>
        /// <param name="stopBits">停止位数</param>
        public SerialDevice(string portName, string baudRate, string parity, string dataBits, string stopBits)
        {

            sp = new SerialPort(portName, Convert.ToInt32(baudRate), getParityFromString(parity), Convert.ToInt32(dataBits), getStopBitsFromString(stopBits));
            //sp.DataReceived += sp_DataReceived;
        }
        #endregion

        public ProtocolStatus Status
        {
            get;
            set;
        }

        public bool Open()
        {
            if (!sp.IsOpen)
            {
                sp.Open();
                this.Status = ProtocolStatus.Opend;
                return true;
            }
            return true;
        }
        public bool isOpen()
        {
            return sp.IsOpen;
        }
        public bool Close()
        {
            if (sp.IsOpen)
            {
                sp.Close();
                this.Status = ProtocolStatus.Closed;
            }
            return true;
        }

        public byte[] Read()
        {
            int count = sp.BytesToRead;
            if (count <= 0)
            {
                return null;
            }
            byte[] rtn = new byte[sp.BytesToRead];
            sp.Read(rtn, 0, rtn.Length);
            return rtn;
        }

        public bool Send(byte[] data)
        {
            sp.Write(data, 0, data.Length);
            return true;
        }

        public bool Send(string data)
        {
            sp.Write(data);
            return true;
        }

        public byte[] GetResponse(byte[] data)
        {
            sp.Write(data, 0, data.Length);
            int timecount = 0;
            while (sp.BytesToRead <= 0 || timecount >= this.ResposeTimeout)
            {
                Thread.Sleep(500);
                timecount += 500;
            }

            if (sp.BytesToRead > 0)
            {
                byte[] rtn = new byte[sp.BytesToRead];
                sp.Read(rtn, 0, rtn.Length);
                return rtn;
            }
            else
            {
                throw new Exception("超时时间已到，未取得任何数据！");
            }

        }

        public string GetResponse(string data)
        {
            sp.Write(data);
            int timecount = 0;
            while (sp.BytesToRead <= 0 || timecount >= this.ResposeTimeout)
            {
                Thread.Sleep(500);
                timecount += 500;
            }

            if (sp.BytesToRead > 0)
            {
                return sp.ReadExisting();
            }
            else
            {
                throw new Exception("超时时间已到，未取得任何数据！");
            }
        }

        public int ResposeTimeout
        {
            get;
            set;
        }

        private Parity getParityFromString(string parity)
        {
            Parity resultParity = Parity.None;
            if (parity.ToUpper() == "EVEN")
            { resultParity = Parity.Even; }
            else if (parity.ToUpper() == "ODD")
            { resultParity = Parity.Odd; }
            else if (parity.ToString() == "MARK")
            { resultParity = Parity.Mark; }
            else if (parity.ToUpper() == "SPACE")
            { resultParity = Parity.Space; }
            return resultParity;
        }
        private StopBits getStopBitsFromString(string stopBits)
        {
            StopBits resultStopBits = StopBits.None;
            if (stopBits == "1")
            { resultStopBits = StopBits.One; }
            else if (stopBits == "1.5")
            { resultStopBits = StopBits.OnePointFive; }
            else if (stopBits == "2")
            { resultStopBits = StopBits.Two; }
            return resultStopBits;
        }

        public byte[] Read(int address, int length)
        {
            throw new NotImplementedException();
        }

        public byte ReadByte()
        {
            throw new NotImplementedException();
        }

        public byte ReadByte(int address)
        {
            throw new NotImplementedException();
        }

        event DataArrivedEvent<string> IProtocol<string>.DataArrived
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        string[] IProtocol<string>.Read()
        {
            throw new NotImplementedException();
        }

        string[] IProtocol<string>.Read(int address, int length)
        {
            throw new NotImplementedException();
        }

        string IProtocol<string>.ReadByte()
        {
            throw new NotImplementedException();
        }

        string IProtocol<string>.ReadByte(int address)
        {
            throw new NotImplementedException();
        }

        public bool Send(string[] data)
        {
            throw new NotImplementedException();
        }

        public string[] GetResponse(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
